includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg

.data
answer dw 42
formatStr db "The answer is %d.", 0dh, 0ah, 0

.code
public main
main proc
	invoke printf, addr formatStr, answer
	ret
main endp
end
