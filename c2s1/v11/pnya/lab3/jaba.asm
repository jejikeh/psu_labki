;----
; length of string
str_len:
    push    ebx
    mov     ebx, eax

next_char:
    cmp     byte[eax], 0
    jz      equal
    inc     eax
    jmp     next_char

equal:
    sub     eax, ebx
    pop     ebx
    ret


;-----
; print string
str_print_unsafe:
    push    edx
    push    ecx
    push    ebx
    push    eax
    call    str_len

    mov     edx, eax
    pop     eax

    mov     ecx, eax
    mov     ebx, 1
    mov     eax, 4
    int     80h

    pop     ebx
    pop     ecx
    pop     edx
    ret


str_print_safe:
    call str_print_unsafe

    push    eax
    mov     eax, 0Ah
    push    eax
    mov     eax, esp
    call    str_print_unsafe
    pop     eax
    pop     eax
    ret


;----
; args
args:
    cmp     ecx, 0h
    jz      exit
    pop     eax
    call    str_print_safe
    dec     ecx
    jmp     args

;----
; exit
exit:
    mov     ebx, 0
    mov     eax, 1
    int     80h
    ret
