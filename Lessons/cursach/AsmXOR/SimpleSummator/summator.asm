.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg

.data
fsNum db "%d ", 0
arr1 dd 0, 0, 0, 0, 0, 1, 1, 0
arr2 dd 0, 0, 0, 0, 0, 1, 0, 0
count dd 8

.code
public main
main proc C
	;xor
	mov ecx, 0
	
	xor_step:
	mov edi, offset arr1		;берем адрес первого массива
	mov eax, [edi + ecx * 4]	;берем очередной элемент 1м
	mov edi, offset arr2		;берем адрес второго массива
	mov ebx, [edi + ecx * 4]	;берем очередной элемент 2м
	xor eax, ebx				;делаем xor элементов
	mov edi, offset arr1		;берем адрес первого массива
	mov [edi + ecx * 4], eax	;кладем результат в 1м

	inc ecx						;увеличиваем счетчик
	cmp [count], ecx			;счетчик == 8
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