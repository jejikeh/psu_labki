; ?????? ?????????? ???????
    .model tiny
    .code
    org 100h
start:  jmp beg
 
; ????? ?????
; x=cx, y=dx, color=al
plot:   push cx
    push dx
    push di
    push es
    cmp cx,320 ; ?????????? ??????? ?? ??????? ?????? ?
    jnc pl1
    cmp dx,200
    jnc pl1
    push ax
    mov ax,320 ; di=320*y+x
    mul dx
    add ax,cx
    mov di,ax
    mov ax,0A000h
    mov es,ax
    pop ax
    mov es:[di],al ; ??????? ?????
pl1:    pop es
    pop di
    pop dx
    pop cx
    ret
 
; ????? ?????
; bx - ????? ?????, ah - ???????????, cx,dx - ?????????? (?????????) ?????, al - ????
 
linetosub:cmp bx,0
    jz lt1
lt0:    call plot ; ????????? ?????
    cmp ah,0  ; ah=0 - ????????? ?? ?????
    jz goN
    cmp ah,1  ; ah=0 - ????????? ?? ????????????
    jz goNE
    cmp ah,2  ; ? ? ? - ????? 8 ????????? ??????????? (0-7)
    jz goE
    cmp ah,3
    jz goSE
    cmp ah,4
        jz goS
    cmp ah,5
    jz goSW
    cmp ah,6
    jz goW
    cmp ah,7
    jz goNW
movcont:dec bx
    jnz lt0
lt1:    ret
goN:    dec dx ; ??????????? ?????
    jmp movcont
goNE:   inc cx
    dec dx
    jmp movcont
goE:    inc cx
    jmp movcont
goSE:   inc cx
    inc dx
    jmp movcont
goS:    inc dx
    jmp movcont
goSW:   dec cx
    inc dx
    jmp movcont
goW:    dec cx
    jmp movcont
goNW:   dec cx
    dec dx
    jmp movcont
 
; ????? - ????? ????? - ???????????,?????,????
lineto  macro direction,size,color
    mov ah,direction
    mov al,color
    mov bx,size
    call linetosub
    endm
 
beg:    push cs
   mov cx,20   ; ????
    mov dx,60
    lineto 3,20,15
    lineto 2,40,15
    lineto 1,20,15
    lineto 6,79,15
    lineto 2,35,15
    lineto 0,60,15
    lineto 3,20,15
    lineto 5,20,15
    pop  bx
    dec  bx
    jnz z1
 
    mov ah,0 ; ??????? ??????? ?? ???????
    int 16h
 
    mov ax,3 ; ?????????? ????????? ?????
    int 10h
    mov ax,4C00h ; ????? ? Dos
    int 21h
    end start