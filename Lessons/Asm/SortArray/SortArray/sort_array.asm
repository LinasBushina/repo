includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg
create_arr proto, pInt : DWORD
get_time proto

.data
arr dw 4, 1, 3, 2, 5, 7, 11, 39, 0			; array of numbers
count dd 0									; counter
flag db 0
formatStr db "%d", 0dh, 0ah, 0				; printf format string
formatStrDahes db "-----", 0dh, 0ah, 0
arr_size dd 1000
arr_addr dd	?	
start_time dd ?

.code
public main
main proc
	invoke create_arr, arr_size
	mov [arr_addr], eax

	print_arr:
	mov edi, [arr_addr]                     ; offset - команда, к-я позволяет получить адрес переменной 
	xor ebx, ebx							; clear counter / обнуляем счетчик 

	print_step:
	mov eax, [edi + ebx * 4]					; get number from array / кладем в регистр edi - начало, ebx - счетчик кладем текущий элемент и печатаем 
	invoke printf, addr formatStr, eax		; печатаем его 

	invoke get_time
	mov [start_time], eax

	inc ebx									; ++
	cmp ebx, [arr_size]					; сравниваем счетчик и длину массива, lengthof - возвращает длину массиива
	jne print_step							; прыжок 
	cmp flag, 0								; сравниваем флажок с нулем чтобы 
	jne exit

	shift:
	mov edi, [arr_addr]						; записываем адрес начала массива
	xor ecx, ecx							; обнуляем

	bubble:	
	mov eax, [edi + ecx * 4]					; записываем элементы 
	mov ebx, [edi + ecx * 4 + 4]
	cmp eax, ebx								; сравниваем
	jle next								; если в правильном порядке то прыжок

	swap:
	mov [edi + ecx * 4], ebx					; в адрес записываем bx
	mov [edi + ecx * 4 + 4], eax				; записываем в ах то есть меняем местами соседние эл-ты
	
	next:									
	inc ecx									; ++
	mov edx, ecx							; записываем копию
	inc edx									; ++
	cmp edx, [arr_size]					; сравниваем
	jne bubble								; если не, то прыыыжок 

	inc [count]
	mov eax, [arr_size]								; count - по сути i
	cmp count, eax					; сравниваем
	jne shift								; не конец то навэрх

	invoke printf, addr formatStrDahes		; печать
	mov [flag], 1							; запись 1 так как все уже прошлися
	;jmp print_arr							; прыгаемс ввэрх 

	exit:
	invoke printf, addr formatStrDahes
	invoke get_time
	sub eax, [start_time]
	invoke printf, addr formatStr, eax

	ret
main endp
end