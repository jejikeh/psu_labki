.model medium
 
.stack  200h
 
.data
        ;Данные
        msgPressAnyKey  db      0Dh, 0Ah, 'Press any key to exit...', '$'
        CrLf            db      0Dh, 0Ah, '$'
        asPrompt        db      'Enter a array:', 0Dh, 0Ah, '$'
        asShowArray     db      0Dh, 0Ah, 'Entered a array:', 0Dh, 0Ah, '$'
        asAverage       db      0Dh, 0Ah, 'Average:', 0Dh, 0Ah, '$'
.data?
        iAverage        dw      ?
        N               dw      ?
        Array           dw      100 dup(?)
 
.code
 
ShowInt16       proc
        push    ax
        push    bx
        push    cx
        push    dx
        push    si
        push    di
        mov     bx,     10
        xor     cx,     cx      ;символов в модуле числа
        or      ax,     ax
        jns     @@div
                neg     ax
                push    ax
                mov     ah,     02h
                mov     dl,     '-'
                int     21h
                pop     ax
        @@div:
                xor     dx,     dx
                div     bx
                push    dx
                inc     cx      ;количество цифр в числе
                or      ax,     ax
        jnz     @@div
        mov     ah,     02h
        @@store:
                pop     dx
                add     dl,     '0'
                int     21h
        loop    @@store
        pop     di
        pop     si
        pop     dx
        pop     cx
        pop     bx
        pop     ax
        ret
ShowInt16       endp
 
;Вывод массива слов (word)
;cx - количество выводимых элементов
;ds:dx - адрес массива слов
ShowArray       proc
        push    ax
        push    bx
        push    cx
        push    dx
        push    si
        push    di
 
        jcxz    @@saExit        ;если массив пустой - завершить
 
        mov     si,     1       ;индекс элемента массива
        mov     di,     dx      ;адрес текущего элемента массива
        @@saForI:
                mov     ax,     [di]
                call    ShowInt16
                mov     ah,     02h
                mov     dl,     ' '
                int     21h
                ;переход к следующему элементу
                inc     si
                add     di,     2
        loop    @@saForI
@@saExit:
        pop     di
        pop     si
        pop     dx
        pop     cx
        pop     bx
        pop     ax
        ret
ShowArray       endp
 
main    proc
        mov     ax,     @data
        mov     ds,     ax
 
        ;программа
        mov     ah,     09h
        lea     dx,     [asPrompt]
        int     21h
        ;ввод массива
        lea     di,     [Array]                 ;
        xor     cx,     cx                      ; n=0
        xor     bx,     bx                      ; x=0
        xor     si,     si                      ; sign=0
        do:                                     ; do{
                mov     ah,     01h             ;    al=getch()
                int     21h
                cmp     al,     '-'             ;    if(al=='-')
                jne     @@IsDigit
                        mov     si,     -1      ;      sign=-1;
                        jmp     do
        @@IsDigit:
                cmp     al,     '0'             ;    if(isdigit(al))
                jb      store
                cmp     al,     '9'
                ja      store
                        push    ax              ;      x=x*10+al-'0'
                        mov     ax,     10
                        mul     bx
                        pop     bx
                        sub     bl,     '0'
                        xor     bh,     bh
                        add     bx,     ax
                        jmp     next
                store:                          ;    else{
                        xor     bx,     si      ;      if(sign==-1)
                        sub     bx,     si      ;      { x= -x;
                        xor     si,     si      ;        sign=0};
                        mov     [di],   bx      ;      a[n]=x
                        add     di,     2
                        inc     cx              ;      n=n+1
                        xor     bx,     bx      ;      x=0
                        cmp     al,     0Dh     ;      if(al=enter)
                        je      break           ;        break;
                                                ;    }
        next:
        jmp     do                              ;  }while(1)
break:
        mov     [N],    cx
 
        mov     ah,     09h
        lea     dx,     [asShowArray]
        int     21h
        mov     cx,     [N]
        lea     dx,     [Array]
        call    ShowArray
 
        mov     cx,     [N]
        lea     si,     [Array]
        xor     bx,     bx
        xor     di,     di
        @@for:
                lodsw
                cwd
                add     bx,     ax
                adc     di,     dx
        loop    @@for
        mov     dx,     di
        mov     ax,     bx
        idiv    [N]
        mov     [iAverage],     ax
        ;вывод результатов
        mov     ah,     09h
        lea     dx,     [asAverage]
        int     21h
        mov     ax,     [iAverage]
        call    ShowInt16
        ;ожидание нажатия любой клавиши
        mov     ah,     09h
        lea     dx,     [msgPressAnyKey]
        int     21h
        mov     ah,     00h
        int     16h
 
        ;завершение программы
        mov     ax,     4C00h
        int     21h
main    endp
 
end     main