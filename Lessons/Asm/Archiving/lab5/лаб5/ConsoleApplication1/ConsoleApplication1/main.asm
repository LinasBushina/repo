.486
.model flat, stdcall
option casemap : none

include win32.inc

.data

endl equ <0dh, 0ah>

inputFilePath byte "simple_in.bmp", 0
outputFilePath byte "simple_out.bmp", 0

hInput dword ?
hStdOut dword ?
bytesWritten dword ?
buf db 54 dup(0)
hOutputFILE dword ?
foo db 3 dup(0)
count db 0
countForWhile dd 0
number1 dd 0
number2 dd 0
number3 dd 3


sFailedToOpenInputFile byte "Failed to open input file", endl
sFailedToOpenInputFileLength dword ($ - sFailedToOpenInputFile)
sFailedToCloseHandle byte "Failed to close handle", endl
sFailedToCloseHandleLength dword ($ - sFailedToCloseHandle)

.code

handleError proc pMessage : dword, messageLength : dword
	invoke WriteConsoleA, hStdOut, pMessage, messageLength, addr bytesWritten, 0

	invoke ExitProcess, 0
	ret
handleError endp

main proc
	invoke GetStdHandle, STD_OUTPUT_HANDLE
	.if eax == INVALID_HANDLE_VALUE
		jmp fatal_error
	.endif
	mov hStdOut, eax

	invoke CreateFileA,addr inputFilePath, GENERIC_READ, DO_NOT_SHARE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL
	.if eax == INVALID_HANDLE_VALUE
		invoke handleError, addr sFailedToOpenInputFile, sFailedToOpenInputFileLength
	.endif
	mov hInput, eax

	invoke CreateFileA, addr outputFilePath, GENERIC_WRITE, DO_NOT_SHARE, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL
	.if eax == INVALID_HANDLE_VALUE
		invoke handleError, addr sFailedToOpenInputFile, sFailedToOpenInputFileLength
	.endif
	mov hOutputFILE, eax

	INVOKE ReadFile, hInput, addr buf, 54, NULL, NULL
	INVOKE WriteFile, hOutputFILE, addr buf, 54, NULL, NULL

	mov ecx, DWORD ptr[buf+34]
	mov esi, ecx

	xor ecx, ecx
	.WHILE countForWhile != esi
		INVOKE ReadFile, hInput, addr foo, 1, NULL, NULL
		INVOKE WriteFile, hOutputFILE, addr foo, 1, NULL, NULL
		inc countForWhile
		;inc count
		;.IF count == 3
		;	mov count, 0
		;	xor ebx, ebx
		;	xor eax, eax

		;	finit

		;	mov bl, [foo]
		;	mov number1, ebx
		;	fild number1
		;	mov al, [foo+1]
		;	mov number2, eax
		;	fiadd number2

		;	xor eax, eax
		;	mov al, [foo+2]
		;	mov number2, eax
		;	fiadd number2

		;	fidiv number3

		;	fist number2
		;	mov bl, byte ptr[number2]
		;	mov [foo], bl
		;	mov [foo+1], bl
		;	mov [foo+2], bl

		;	INVOKE WriteFile, hOutputFILE,addr foo, 3, NULL, NULL
		;.endif
	.endw

	invoke CloseHandle, hOutputFILE
	.if eax == FALSE
		invoke handleError, addr sFailedToCloseHandle, sFailedToCloseHandleLength
	.endif
	invoke CloseHandle, hInput
	.if eax == FALSE
		invoke handleError, addr sFailedToCloseHandle, sFailedToCloseHandleLength
	.endif

fatal_error:
	invoke ExitProcess, 0
main endp

end main
