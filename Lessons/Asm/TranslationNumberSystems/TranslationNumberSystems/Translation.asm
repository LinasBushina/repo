includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg
scanf proto, pString : ptr byte, arg : ptr byte

.data
fsEnterNum db "Enter num: ", 0
fsScanf db "%d", 0
fsEnterFrom db "Enter from number system: ", 0
fsEnterTo db "Enter to number system: ", 0
fsPrintNum db "%d", 0dh, 0ah, 0
num dd 0
from dd 0
to dd 0
res_mod dd 0
res_div dd 0
sum dd 0
pow dd 0

.code
public main
main proc
	invoke printf, addr fsEnterNum
	invoke scanf, addr fsScanf, addr num
	invoke printf, addr fsEnterFrom
	invoke scanf, addr fsScanf, addr from
	invoke printf, addr fsEnterTo
	invoke scanf, addr fsScanf, addr to

	mov [pow], 1
	radix:
	mov eax, [num]
	mov ebx, 10
    xor edx, edx
    div ebx			;div in edx:eax, mod in edx
	mov [res_mod], edx
	mov [res_div], eax

	mov eax, [res_mod]
    xor edx, edx
	mov ebx, [pow]
	mul ebx			;mul in edx:eax

	add eax, [sum]
	mov [sum], eax

	mov eax, [pow]
    xor edx, edx
	mov ebx, [from]
	mul ebx
	mov [pow], eax

	mov eax, [res_div]
	mov [num], eax
	cmp eax, 0
	jne radix

	invoke printf, addr fsPrintNum, sum
	;invoke printf, addr fsPrintNum, edx

	ret
main endp
end