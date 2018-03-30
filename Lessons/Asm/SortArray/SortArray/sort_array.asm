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
	mov edi, [arr_addr]                     ; offset - �������, �-� ��������� �������� ����� ���������� 
	xor ebx, ebx							; clear counter / �������� ������� 

	print_step:
	mov eax, [edi + ebx * 4]					; get number from array / ������ � ������� edi - ������, ebx - ������� ������ ������� ������� � �������� 
	invoke printf, addr formatStr, eax		; �������� ��� 

	invoke get_time
	mov [start_time], eax

	inc ebx									; ++
	cmp ebx, [arr_size]					; ���������� ������� � ����� �������, lengthof - ���������� ����� ��������
	jne print_step							; ������ 
	cmp flag, 0								; ���������� ������ � ����� ����� 
	jne exit

	shift:
	mov edi, [arr_addr]						; ���������� ����� ������ �������
	xor ecx, ecx							; ��������

	bubble:	
	mov eax, [edi + ecx * 4]					; ���������� �������� 
	mov ebx, [edi + ecx * 4 + 4]
	cmp eax, ebx								; ����������
	jle next								; ���� � ���������� ������� �� ������

	swap:
	mov [edi + ecx * 4], ebx					; � ����� ���������� bx
	mov [edi + ecx * 4 + 4], eax				; ���������� � �� �� ���� ������ ������� �������� ��-��
	
	next:									
	inc ecx									; ++
	mov edx, ecx							; ���������� �����
	inc edx									; ++
	cmp edx, [arr_size]					; ����������
	jne bubble								; ���� ��, �� �������� 

	inc [count]
	mov eax, [arr_size]								; count - �� ���� i
	cmp count, eax					; ����������
	jne shift								; �� ����� �� ������

	invoke printf, addr formatStrDahes		; ������
	mov [flag], 1							; ������ 1 ��� ��� ��� ��� ��������
	;jmp print_arr							; �������� ����� 

	exit:
	invoke printf, addr formatStrDahes
	invoke get_time
	sub eax, [start_time]
	invoke printf, addr formatStr, eax

	ret
main endp
end