includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg ; обьявляем прототипы функций, возвращаемое зн-е не указ.
scanf proto, pString : ptr byte, args : ptr byte
strlen proto, pString : ptr byte ; вычисляем длину строки т.е. прототип функции

.data
fsPrintfEnterStr db "Enter string: ", 0
fsScanfStr db "%s", 0
fsPrintfChar db "%c", 0
fsPrintfCharChar db "%c%d", 0
fsPrintfCharCharEnd db "%c%d", 10, 13, 0
strBuf db 50 dup(?)
archBuf db 50 dup(0)
indexStr dd 1
indexArch dd 0
count db 1
symbol db ?

.code
public main
main proc
	invoke printf, addr fsPrintfEnterStr
	invoke scanf, addr fsScanfStr, addr strBuf

	mov edi, offset strBuf
	mov eax, [edi]
	mov [symbol], al

	cycle_iter:
	invoke strlen, addr strBuf
	mov ecx, [indexStr]
	cmp eax, ecx
	je deachive

	mov edi, offset strBuf
	mov ecx, [indexStr]
	mov eax, [edi + ecx]
	cmp al, [symbol]
	jne not_eq_symb

	eq_symb:
	inc [count]
	inc [indexStr]
	jmp jump_cycle_iter

	not_eq_symb:
	mov edi, offset archBuf
	mov ecx, [indexArch]
	mov al, [symbol]
	mov [edi + ecx], al
	inc ecx
	mov al, [count]
	mov [edi + ecx], al
	invoke printf, addr fsPrintfCharChar, symbol, al
	mov edi, offset strBuf
	mov ecx, [indexStr]
	mov eax, [edi + ecx]
	mov [symbol], al
	mov [count], 1
	inc [indexStr]
	inc [indexArch]
	inc [indexArch]

	jump_cycle_iter:
	jmp cycle_iter

	deachive:
	mov edi, offset archBuf
	mov ecx, [indexArch]
	mov al, [symbol]
	mov [edi + ecx], al
	inc ecx
	mov al, [count]
	mov [edi + ecx], al
	invoke printf, addr fsPrintfCharCharEnd, symbol, al
	mov [indexArch], 0

	deachive_step:
	mov edi, offset archBuf
	mov ecx, [indexArch]
	mov eax, [edi + ecx]
	mov [symbol], al
	inc ecx
	mov eax, [edi + ecx]
	mov [count], al

	print_step:
	invoke printf, addr fsPrintfChar, symbol
	dec [count]
	cmp [count], 0
	jne print_step

	inc [indexArch]
	inc [indexArch]
	invoke strlen, addr archBuf
	cmp eax, indexArch
	jne deachive_step

	ret
main endp
end