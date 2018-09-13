includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg

.data
x dw 1
formatStr db "%d", 0dh, 0ah, 0

.code
public main
main proc
my_boop:
	invoke printf, addr formatStr, x
	inc x 
	mov ax, x
	cmp ax, 11
	jne my_boop 
	ret
main endp
end