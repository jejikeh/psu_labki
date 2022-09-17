SECTION	.data
msg	db	"Hello World", 0Ah

SECTION .text
global	_start

_start:
	
	mov	edx, 13		; number of bytes to write
	mov	ecx, msg	; move the memory addres
	mov	ebx, 1		; wrute to the stdout file
	mov	eax, 4		; invoke sys_write (kernel opcode 4)
	int	80h

	mov	ebx, 0		; return 0 - 'no errors'
	mov	eax, 1		; invoke sys_exit (kerne; opcode 1)
	int	80h
