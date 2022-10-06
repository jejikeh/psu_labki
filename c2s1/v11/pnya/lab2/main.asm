%include        'function.asm'                             ; include our external file
 
SECTION .data
msg0    db      'абвгд', 0Ah , 0h              ; our first message string
msg1    db      'еёзжх', 0Ah , 0h              ; our first message string
msg2    db      'уюкмал', 0Ah , 0h     ; our second message string
msg3    db      'кырвл', 0Ah , 0h     ; our second message string
 
SECTION .text
global  _start
 
_start:
 
    mov     eax, msg0       ; move the address of our first 
    call    sprint          ; call our string printing function
    mov     eax, msg1       ; move the address of our 
    call    sprint          ; call our string printing function
    mov     eax, msg2       ; move the address of our 
    call    sprint          ; call our string printing function
    mov     eax, msg3       ; move the address of our 
    call    sprint          ; call our string printing function
    call    quit            ; call our quit function