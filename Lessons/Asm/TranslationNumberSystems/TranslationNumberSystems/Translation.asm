;includelib libcmt.lib
includelib libcmt.lib
includelib libvcruntime.lib
includelib libucrt.lib
includelib legacy_stdio_definitions.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg ; обьявляем прототипы функций, возвращаемое зн-е не указ.
scanf proto, pString : ptr byte, args : ptr byte
strlen proto, pString : ptr byte ; вычисляем длину строки т.е. прототип функции
strcat proto, dest : ptr byte, src : ptr byte ; склеивание строк

.data
fsEnterNum db "Enter num: ", 0 ; для счит и печати
fsScanfNum db "%s", 0
fsScanfBase db "%d", 0
fsEnterFrom db "Enter from number system: ", 0
fsEnterTo db "Enter to number system: ", 0
fsPrintNum db "%d", 0dh, 0ah, 0
numBuf db 20 dup(?) ; дубликейт
from dd ? ; степень из которой переводим в к-е записано число
to dd ? 
digit dd ?
sum dd 0
pow dd 1
index dd ?
len dd ?
bufflag db 0 
resbuf_1 db 50 dup(0)
resbuf_2 db 50 dup(0)

.code
public main
main proc C
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

	radix:                  ; определение символ цифры /символ буквы
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

	save_digit:          ; получаем цифру
	mov [digit], eax

	; digit * from^radix 
	mov eax, [digit]
    xor edx, edx
	mov ebx, [pow]
	mul ebx			;mul in edx:eax

	; sum += digit * from^radix
	add eax, [sum]
	mov [sum], eax

	; pow *= from 
	mov eax, [pow]
    xor edx, edx
	mov ebx, [from]
	mul ebx
	mov [pow], eax

	mov eax, [index] ; движемся к след разряду
	dec eax
	mov [index], eax
	cmp eax, -1 ; пока не доконца дошли
	jne radix

	invoke printf, addr fsPrintNum, sum ; десятичное представление печатаем

	convert_to:     ; делим
	mov eax, [sum]
	mov ebx, [to]
	xor edx, edx
	div ebx									;mod in edx, div in eax
	
	mov [sum], eax        ; сохраняем 
	mov [digit], edx
	cmp edx, 9            ; сравниваем
	jg buf_hex

	buf_dec:
	mov eax, [digit]
	add eax, 48
	jmp concat_digit

	buf_hex:
	mov eax, [digit]
	add eax, 55

	concat_digit:
	mov [digit], eax
	cmp bufflag, 0
	jne resbuf_two

	resbuf_one:
	mov eax, [digit]
	mov [resbuf_1], al
	mov [resbuf_1 + 1], 0
	invoke strcat, addr resbuf_1, addr resbuf_2
	jmp check_sum

	resbuf_two:
	mov eax, [digit]
	mov [resbuf_2], al
	mov [resbuf_2 + 1], 0
	invoke strcat, addr resbuf_2, addr resbuf_1

	check_sum:  ; инвертируем 
	mov eax, 1
	sub al, bufflag
	mov [bufflag], al
	
	mov eax, [sum] ; сравнение 0 -конец
	cmp eax, 0
	jne convert_to ; прыгаем обратно

	print_ast_to:
	cmp bufflag, 0
	jne print_res_2

	print_res_1:
	invoke printf, addr fsScanfNum, addr resbuf_2
	jmp endret

	print_res_2:
	invoke printf, addr fsScanfNum, addr resbuf_1

	endret:
	ret
main endp
end