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
	mov edi, offset arr1		;����� ����� ������� �������
	mov eax, [edi + ecx * 4]	;����� ��������� ������� 1�
	mov edi, offset arr2		;����� ����� ������� �������
	mov ebx, [edi + ecx * 4]	;����� ��������� ������� 2�
	xor eax, ebx				;������ xor ���������
	mov edi, offset arr1		;����� ����� ������� �������
	mov [edi + ecx * 4], eax	;������ ��������� � 1�

	inc ecx						;����������� �������
	cmp [count], ecx			;������� == 8
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