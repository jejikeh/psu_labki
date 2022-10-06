.model	small
.stack	100h
.data
            
MaxArrayLength              equ 30            
            
ArrayLength                 db  ?
InputArrayLengthMsgStr      db  0Dh,'Input array length: $'
InputLowerBoundMsgStr       db  0Dh,'Input lower bound: $'  
InputHigherBoundMsgStr      db  0Dh,'Input higher bound: $'  
                                
ErrorInputMsgStr            db  0Dh,'Incorrect value!',0Ah, '$' 
ErrorInputHigherBoundMsgStr db  0Dh,'Higher bound should be geater than lower bound!', 0Ah, '$' 
ErrorInputArrayLengthMsgStr db  0Dh,'Array length should be geater than 0 and not grater than 30!', 0Ah, '$'
                                
InputMsgStr                 db  0Dh,'Input '    
CurrentEl                   db  2 dup(0)
InputMsgStrEnding           db  ' element (-127..127) : $'     
enterStr                    db  0Ah, 0Dh, '$'

Answer                      db  2 dup(0)
ResultMsgStr                db  0Dh, 'Result: $'
                                
Buffer                      db  ?
                                                              
MaxNumLen                   db  5  
Len                         db  ?                          ;Contains length of entered string
buff                        db  5 dup (0)              
                                
minus                       db  0  

Array                       db  MaxArrayLength dup (0) 
                                
LowerBound                  db  ?
HigherBound                 db  ?
                              
.code      
start:                            ;
mov	ax,@data                      ;
mov	ds,ax                         ;
                                  ;
xor	ax,ax                         ;
                                  ;
call input                        ;
call Do                           ;
call output                       ;
                                  ;
                                  ;
input proc                        ;
    call inputLowerBound          ;
    call inputHigherBound         ;
    call inputArrayLength         ;
    call inputArray               ;
                                  ;
    ret                           ;
endp     


inputLowerBound proc
    mov cx, 1                         
    inputLowerBoundLoop:
       call ShowInputLowerBoundMsg                    
       call inputElementBuff          
       
       test ah, ah
       jnz inputLowerBoundLoop 
       
       mov bl, Buffer 
       mov LowerBound, bl
    loop inputLowerBoundLoop                
    ret      
endp    

inputHigherBound proc                                    
    mov cx, 1                         
    inputHigherBoundLoop:
       call ShowInputHigherBoundMsg                    ;
       call inputElementBuff         
              
       test ah, ah
       jnz inputHigherBoundLoop 
       
       mov ah, LowerBound
       cmp Buffer,ah                                          
       jnl inputHigherBoundLoop_OK
       
       call ShowErrorInputHigherBoundMsgStr 
       jmp inputHigherBoundLoop
       
       inputHigherBoundLoop_OK:
       
       mov bl, Buffer 
       mov HigherBound, bl
    loop inputHigherBoundLoop
    ret      
endp     

inputArrayLength proc   
    mov cx, 1           
    inputArrayLengthLoop:
       call ShowInputArrayLengthMsg                    ;
       call inputElementBuff          
       
       test ah, ah
       jnz inputArrayLengthLoop 
       
       cmp Buffer, MaxArrayLength
       jg inputArrayLengthLoop_FAIL   
       
       cmp Buffer, 0
       jg inputArrayLengthLoop_OK   
       ;jmp inputArrayLengthLoop_FAIL
       
       inputArrayLengthLoop_FAIL:
       
       call ShowErrorInputArrayLengthMsgStr 
       jmp inputArrayLengthLoop
       
       inputArrayLengthLoop_OK:
       
       mov bl, Buffer 
       mov ArrayLength, bl                 
    loop inputArrayLengthLoop     
    ret      
endp 

inputArray proc
    xor di,di                     
                                               
    mov cl,ArrayLength            
    inputArrayLoop:
       call ShowInputMsg                    ;
       call inputElementBuff      
       
       test ah, ah
       jnz inputArrayLoop
       
       mov bl, Buffer 
       mov Array[di], bl
       inc di                     
    loop inputArrayLoop           
    ret      
endp  


resetBuffer proc
    mov Buffer, 0    
    ret
endp    

inputElementBuff proc                 
    push cx                       
    inputElMain:                  
        call resetBuffer          
        
        mov ah,0Ah                  
        lea dx, MaxNumLen         
        int 21h                   
                                  
        mov dl,10                 
        mov ah,2                  
        int 21h                   
                                  
        cmp Len,0                 
        je errInputEl             
                                  
        mov minus,0               
        xor bx,bx                 
                                  
        mov bl,Len                
        lea si,Len                
                                  
        add si,bx                 
        mov bl,1                  
                                  
                                  
        xor cx,cx                 
        mov cl,Len                
        inputElLoop:              
            std                   
            lodsb                 
                                  
            call checkSym         
                                  
            cmp ah,1              
            je errInputEl         
                                  
            cmp ah,2               
            je nextSym            
                                  
            sub al,'0'            
            mul bl                
                                  
            test ah,ah            
            jnz errInputEl        
                                  
            add Buffer,al      
                                  
            jo errInputEl         
            js errInputEl         
                                  
            mov al,bl             
            mov bl,10             
            mul bl                
                                  
            test ah,ah            
            jz ElNextCheck        
                                   
                                  
            cmp ah,3              
            jne errInputEl                                          
                                  
            ElNextCheck:          
                mov bl,al         
                jmp nextSym       
                                  
                                  
            errInputEl:           
                call ShowErrorInputMsg   
                jmp exitInputEl          
                                  
            nextSym: 
            xor ah, ah            
        loop inputElLoop          
                                  
    cmp minus,0                   
    je exitInputEl                
    neg Buffer                    
                                  
    exitInputEl:                  
    pop cx                        
    ret                           
endp 
                                  
checkSym proc                     
    cmp al,'-'                    
    je minusSym                   
                                  
    cmp al,'9'                    
    ja errCheckSym                
                                  
    cmp al,'0'                    
    jb errCheckSym                
                                  
    jmp exitCheckGood             
                                  
    minusSym:                     
        cmp si,offset Len         
        je exitWithMinus          
                                  
    errCheckSym:                  
        mov ah,1                  
        jmp exitCheckSym          
                                  
    exitWithMinus:                
        mov ah,2                  
        mov minus, 1              
        cmp Len, 1                
        je errCheckSym            
                                  
        jmp exitCheckSym          
                                  
    exitCheckGood:                
        xor ah,ah                  
    exitCheckSym:                 
        ret                       
endp                              
                                  
ShowErrorInputMsg proc            
    lea dx, ErrorInputMsgStr      
    mov ah, 09h                   
    int 21h                       
    ret                           
endp                              
      

ShowInputArrayLengthMsg proc
    push ax
    push dx
      
    mov ah,09h                      
    lea dx, InputArrayLengthMsgStr           
    int 21h  
    
    pop ax
    pop dx 
     
    ret
endp       
         
ShowInputLowerBoundMsg proc
    push ax
    push dx
      
    mov ah,09h                      
    lea dx, InputLowerBoundMsgStr           
    int 21h  
    
    pop ax
    pop dx 
     
    ret
endp    

ShowInputHigherBoundMsg proc
    push ax
    push dx
      
    mov ah,09h                      
    lea dx, InputHigherBoundMsgStr           
    int 21h  
    
    pop ax
    pop dx 
     
    ret
endp  
                                  
ShowInputMsg proc                 
    mov ax,di                     
              
    mov ax, di         
    mov bl, 10
    div bl          
              
    push di
        
    xor di, di    
    inc di
    mov CurrentEl[di], ah
    add CurrentEl[di], '0'
    
    test al, al 
    jz lessThanTen
    
    dec di
    mov CurrentEl[di], al                      
    add CurrentEl[di], '0'           
           
    lessThanTen:                      
    mov ah,09h                    
    lea dx, InputMsgStr           
    int 21h   
    
    pop di
    ret                           
endp    

ShowErrorInputHigherBoundMsgStr proc
    push ax
    push dx
      
    mov ah,09h                      
    lea dx, ErrorInputHigherBoundMsgStr           
    int 21h  
    
    pop ax
    pop dx 
     
    ret
endp       

ShowErrorInputArrayLengthMsgStr proc
    push ax
    push dx
      
    mov ah,09h                      
    lea dx, ErrorInputArrayLengthMsgStr           
    int 21h  
    
    pop ax
    pop dx 
     
    ret
endp


CheckMatch proc                   
    mov ah, LowerBound            
    cmp Array[di],ah                                   
    jl notMatch                   
    mov ah, HigherBound           
    cmp Array[di],ah              
    jg notMatch                   
                                  
    inc bx                                           
                                  
    notMatch:                     
    ret                           
endp                              
                                  
Do proc                           
    xor bx, bx                    
    mov cl,ArrayLength            
    xor di, di                    
    DoLoop:                       
        call CheckMatch           
        inc  di                   
    loop DoLoop                   
    ret                           
endp                              
                                  
output proc                       
    lea dx, ResultMsgStr                                                                  
    mov ah, 09h
    int 21h
            
    mov ax, bx         
    mov al, bl
    mov bl, 10
    div bl
                   
    xor di, di    
    inc di
    mov Answer[di], ah
    add Answer[di], '0'
    
    test al, al 
    jz lessThanTen1
    
    dec di
    mov Answer[di], al                      
    add Answer[di], '0'           
           
    lessThanTen1:                      
    
    lea dx, Answer
    mov ah, 09h 
    int 21h      
    
    lea dx, enterStr
    mov ah, 09h 
    int 21h  
        
    xor ax, ax                              ;
    mov	ah,4ch                    
    int	21h                       
    ret                           
endp                              
                                  
end	start                         