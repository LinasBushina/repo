includelib libcmt.lib

.386
.model flat, c
.stack 4096
printf proto, pString : ptr byte, args : vararg

.data
num1 equ 20 ; начальное число
num2 equ 5 ; количество чисел
x db 1 ; делимое
y dw 0 ; счетчик
z dw 0 ; конечное простое число
formatStr db "%d", 0dh, 0ah, 0

.code
public main
main proc
mov ax, num1
mov z, num1
jmp func1
func2: 
	inc z
	mov x , 1

func1:
	;jmp func2
	mov ax, z
	inc x
	div x
	cmp ah, 0
	jne func1

cmp al, 1
jne func2

func3:
invoke printf, addr formatStr, z
inc y
cmp y,num2
jne func2

	ret
main endp
end