includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg
scanf proto, pString : ptr byte, arg : ptr byte
strlen proto, pString : ptr byte

.data
fsEnterNum db "Enter num: ", 0
fsScanfNum db "%s", 0
fsScanfBase db "%d", 0
fsEnterFrom db "Enter from number system: ", 0
fsEnterTo db "Enter to number system: ", 0
fsPrintNum db "%d", 0dh, 0ah, 0
numBuf db 20 dup(?)
from dd ?
to dd ?
digit dd ?
sum dd 0
pow dd 1
index dd ?
len dd ?

.code
public main
main proc
	invoke printf, addr fsEnterNum
	invoke scanf, addr fsScanfNum, addr numBuf
	invoke printf, addr fsEnterFrom
	invoke scanf, addr fsScanfBase, addr from
	invoke printf, addr fsEnterTo
	invoke scanf, addr fsScanfBase, addr to

	; len = strlen(numBuf)
	invoke strlen, addr numBuf
	mov [len], eax
	dec eax
	mov [index], eax

	radix:
	mov edi, offset numBuf
	mov ebx, [index]
	mov eax, [edi + ebx]
	xor ebx, ebx
	mov bl, al
	mov eax, ebx
	mov [digit], eax
	cmp eax, 58
	jg hex_digit

	decimal_digit:
	mov eax, [digit]
	sub eax, 48
	jmp save_digit

	hex_digit:
	mov eax, [digit]
	sub eax, 55

	save_digit:
	mov [digit], eax

	; digit * pow^radix
	mov eax, [digit]
    xor edx, edx
	mov ebx, [pow]
	mul ebx			;mul in edx:eax

	; sum += digit * pow^radix
	add eax, [sum]
	mov [sum], eax

	; pow *= from
	mov eax, [pow]
    xor edx, edx
	mov ebx, [from]
	mul ebx
	mov [pow], eax

	mov eax, [index]
	dec eax
	mov [index], eax
	cmp eax, -1
	jne radix

	invoke printf, addr fsPrintNum, sum

	ret
main endp
end