includelib libcmt.lib

.386
.model flat, c

.stack 4096
printf proto, pString : ptr byte, args : vararg
get_output proto, :DWORD


.data
num1 db 00000011b
num2 db 00000010b
StrFormat1	byte "Result :",10,13,0
formatStr db "%o", 0dh, 0ah, 0
buf dd 0
buf2 dw 0
MyFlags dw 0


.code
main proc
xor ecx,ecx
mov cl,num1
add cl,num2
mov buf,ecx
invoke printf, addr StrFormat1, 0
invoke get_output, buf








ret

main  endp
end 
