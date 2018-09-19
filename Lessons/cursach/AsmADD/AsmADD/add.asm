includelib libcmt.lib
includelib libvcruntime.lib
includelib libucrt.lib
includelib legacy_stdio_definitions.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg

.data
fsNum db "%d ", 0
arr1 dd 0, 0, 0, 0, 0, 1, 1, 0
arr2 dd 0, 0, 0, 0, 0, 1, 0, 0
count dd 8
carry dd 0

.code
public main
main proc C
	;xor
	mov ecx, 7
	
	xor_step:
	mov edi, offset arr1		;берем адрес первого массива
	mov eax, [edi + ecx * 4]	;берем очередной элемент 1м
	mov edi, offset arr2		;берем адрес второго массива
	mov ebx, [edi + ecx * 4]	;берем очередной элемент 2м
	add eax, ebx				;делаем add элементов
	add eax, [carry]

	cmp eax, 2
	je	one_one_case
	cmp eax, 3
	je	one_one_case
	mov [carry], 0
	jmp put_to_arr1

	one_one_case:
	mov [carry], 1
	mov eax, 0
	jmp put_to_arr1

	one_one_one_case:
	mov [carry], 1
	mov eax, 1

	put_to_arr1:
	mov edi, offset arr1		;берем адрес первого массива
	mov [edi + ecx * 4], eax	;кладем результат в 1м

	dec ecx						;увеличиваем счетчик
	cmp ecx, -1			;счетчик == -1
	jne xor_step				;jump not equal

	print_step:
	mov edi, offset arr1
	mov eax, [count]
	mov ecx, 8
	sub ecx, eax
	mov eax, [edi + ecx * 4]
	invoke printf, addr fsNum, eax

	dec [count]
	cmp [count], 0
	jne print_step

	ret
main endp
end