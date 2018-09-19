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
arr dd 1, 1, 0, 0, 0, 1, 0, 1
count dd 8
shift dd 1

.code
public main
main proc C
	;shl
	mov ecx, 0
	
	shl_step:
	mov eax, ecx
	sub eax, [shift]
	cmp eax, 0
	jl skip

	mov edi, offset arr		
	mov ebx, [edi + ecx * 4]	
	mov [edi + eax * 4], ebx

	skip:
	inc ecx						
	cmp [count], ecx			
	jne shl_step				

	;right_zeros
	mov ecx, [count]
	dec ecx

	zero_step:
	cmp [shift], 0
	je print_step

	mov edi, offset arr		
	mov eax, 0
	mov [edi + ecx * 4], eax

	dec ecx
	dec [shift]
	cmp ecx, -1
	jne zero_step

	print_step:
	mov edi, offset arr
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