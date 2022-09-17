%include 'jaba.asm'

SECTION .data
msg	db	"Hello, WORLD WORLD WORLD", 0h
msg1	db	"Hello, asm", 0h


SECTION .text
global	_start

_start:
	pop		ecx
	call 	args

