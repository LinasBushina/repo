.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg ; ��������� ��������� �������, ������������ ��-� �� ����.

.data
fsHello db "Sum: %d\n", 0

.code
public main
main proc C
	mov eax, 7
	mov ebx, 4
	add eax, ebx

	invoke printf, addr fsHello, eax
	ret
main endp
end