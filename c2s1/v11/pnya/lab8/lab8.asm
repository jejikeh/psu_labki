; LAB8.COM 2 second.exe
.model tiny
 
.code
 
        org     100h
main    proc
 
start:
        ;программа
 
        ;обрабатываем командную строку
        ; - считываем количество запусков программы - первый параметр
        mov     cl,     ds:[80h]
        cmp     cl,     1
        ja      @@GetN
        @@ShowAbout:
                mov     ah,     09h
                lea     dx,     [asAbout]
                int     21h
                jmp     @@exit
        @@GetN:
                xor     ch,     ch
                dec     cx
                mov     si,     82h     ;адрес первого значимого символа строки
                                        ;(DTA+2 в PSP)
                mov     bh,     10
                xor     al,     al
                @@getc:
                        mov     bl,     [si]
                        inc     si
                        cmp     bl,     ' '
                        je      @@storeN
                        sub     bl,     '0'
                        jb      @@ShowAbout
                        cmp     bl,     9
                        ja      @@ShowAbout
                        mul     bh
                        add     al,     bl
                        adc     ah,     0
                        test    ah,     ah
                        jnz     @@ShowAbout
                loop    @@getc
        @@storeN:
                mov     [N],    ax
        @@GetFileName:
                jcxz    @@ShowAbout
                @@SkipSpaces:
                        mov     al,     [si]
                        inc     si
                        cmp     al,     ' '
                loopz   @@SkipSpaces
                jcxz    @@ShowAbout
                dec     si
                mov     word ptr[lpChildProcess],       si
                mov     word ptr[lpChildProcess+2],     ds
                mov     bx,     81h
                add     bl,     ds:[80h]
                mov     byte ptr ds:[bx],       0
 
        ;несколько (N) раз запуск внешней программы
        mov     cx,     [N]
        @@for:
                push    cx
                call    StartProcess
                pop     cx
        loop    @@for
 
 
        ;завершение программы
@@exit:
        xor     ax,     ax
        int     16h
        int     20h
 
main    endp
 
StartProcess    proc
        ;уменьшаем объём памяти, выделенной
        ;операционной системой при запуске
        ;для родительской программы
        mov     ah,     4Ah
        mov     bx,     1000h   ;не долго думая - до размеров одного сегмента
        ;es - указывает на PSP
        int     21h
        ;подготовка к вызову EXEC
        ;- Сохраните текущие значения
        ;  SS, SP, DS, ES и DTA в переменных,
        ;  адресуемых через регистр CS
        push    es
        push    ds
        mov     cs:[stkseg],    ss
        mov     cs:[stkptr],    sp
        ;- подготовка блока параметров
        mov     ax,     ds:[2Ch]
        mov     [wEnvSeg],      ax
        mov     ax,     cs      ;поместить в ax сегмент PSP
        mov     word ptr[pfrFCB_1],     005Ch
        mov     word ptr[pfrFCB_1+2],   ax
        mov     word ptr[pfrFCB_2],     006Ch
        mov     word ptr[pfrFCB_2+2],   ax
        mov     word ptr[pfCmdTail],    offset ChildParams
        mov     word ptr[pfCmdTail+2],  ax
        ;вызов EXEC - внешней программы
        mov     ax,     4B00h
        lea     bx,     [ExecParamRec]          ;es:bx
        lds     dx,     [lpChildProcess]        ;ds:dx
        int     21h
        ;Восстановите локальные значения SS и SP
        cli                     ; (for bug in some early 8088s)
        mov     ss,cs:[stkseg]  ; restore stack pointer
        mov     sp,cs:[stkptr]
        sti                     ; (for bug in some early 8088s)
        ;Восстановите DS, ES и локальную DTA, если необходимо.
        pop     ds
        pop     es
        ;Проверьте флаг CF, чтобы узнать, не было ли ошибки при EXEC.
        jnc     @@ExecOk
                ;вывод сообщение об ошибке вызова EXEC
                mov     ah,     09h
                lea     dx,     [asErrExec]
                int     21h
        @@ExecOk:
        ;Проверьте код выхода через функцию 4dH WAIT (если надо).
 
        ret
StartProcess    endp
 
.data
        ;Данные
        CrLf            db      0Dh, 0Ah, '$'
        asErrExec       db      0Dh, 0Ah, "Exec failed", 0Dh, 0Ah, '$'
        asAbout         db      0Dh, 0Ah, "Use:", 0Dh, 0Ah
                        db      "myprog.com NNN filename.ext", 0Dh, 0Ah
                        db      " NNN - a number of starts (1...255)", 0Dh, 0Ah
                        db      " filename.ext - process", 0Dh, 0Ah, '$'
        ChildParams     db      0, 0Dh
.data?
        N               dw      ?
        stkseg          dw      ?               ; save SS register
        stkptr          dw      ?               ; save SP register
        lpChildProcess  dd      ?
        ExecParamRec    label   byte
                wEnvSeg         dw      ?
                pfCmdTail       dd      ?
                pfrFCB_1        dd      ?
                pfrFCB_2        dd      ?
 
end     main