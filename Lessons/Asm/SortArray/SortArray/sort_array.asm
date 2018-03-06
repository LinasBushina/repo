includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg

.data
arr dw 4, 1, 3, 2, 5, 7, 11, 39, 0			; array of numbers
count dw 0									; counter
flag db 0
formatStr db "%d", 0dh, 0ah, 0				; printf format string
formatStrDahes db "-----", 0dh, 0ah, 0			

.code
public main
main proc
	print_arr:
	mov edi, OFFSET arr                     ; offset - команда, к-я позволяет получить адрес переменной 
	xor ebx, ebx							; clear counter / обнуляем счетчик 

	print_step:
	mov ax, [edi + ebx * 2]					; get number from array / кладем в регистр edi - начало, ebx - счетчик кладем текущий элемент и печатаем 
	invoke printf, addr formatStr, ax		; печатаем его 

	inc ebx									; ++
	cmp ebx, LENGTHOF arr					; сравниваем счетчик и длину массива, lengthof - возвращает длину массиива
	jne print_step							; прыжок 
	cmp flag, 0								; сравниваем флажок с нулем чтобы 
	jne exit

	shift:
	mov edi, OFFSET arr						; записываем адрес начала массива
	xor ecx, ecx							; обнуляем

	bubble:	
	mov ax, [edi + ecx * 2]					; записываем элементы 
	mov bx, [edi + ecx * 2 + 2]
	cmp ax, bx								; сравниваем
	jle next								; если в правильном порядке то прыжок

	swap:
	mov [edi + ecx * 2], bx					; в адрес записываем bx
	mov [edi + ecx * 2 + 2], ax				; записываем в ах то есть меняем местами соседние эл-ты
	
	next:									
	inc ecx									; ++
	mov edx, ecx							; записываем копию
	inc edx									; ++
	cmp edx, LENGTHOF arr					; сравниваем
	jne bubble								; если не, то прыыыжок 

	inc [count]								; count - по сути i
	cmp count, LENGTHOF arr					; сравниваем
	jne shift								; не конец то навэрх

	invoke printf, addr formatStrDahes		; печать
	mov [flag], 1							; запись 1 так как все уже прошлися
	jmp print_arr							; прыгаемс ввэрх 

	exit:
	ret
main endp
end