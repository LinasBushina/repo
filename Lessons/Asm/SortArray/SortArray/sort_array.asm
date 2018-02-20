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
	mov edi, OFFSET arr
	xor ebx, ebx							; clear counter

	print_step:
	mov ax, [edi + ebx * 2]					; get number from warray
	invoke printf, addr formatStr, ax		; increment counter

	inc ebx
	cmp ebx, LENGTHOF arr
	jne print_step
	cmp flag, 0
	jne exit

	shift:
	mov edi, OFFSET arr
	xor ecx, ecx	

	bubble:	
	mov ax, [edi + ecx * 2]
	mov bx, [edi + ecx * 2 + 2]
	cmp ax, bx
	jle next

	swap:
	mov [edi + ecx * 2], bx
	mov [edi + ecx * 2 + 2], ax
	
	next:
	inc ecx
	mov edx, ecx
	inc edx
	cmp edx, LENGTHOF arr
	jne bubble

	inc [count]
	cmp count, LENGTHOF arr
	jne shift

	invoke printf, addr formatStrDahes
	mov [flag], 1
	jmp print_arr 

	exit:
	ret
main endp
end