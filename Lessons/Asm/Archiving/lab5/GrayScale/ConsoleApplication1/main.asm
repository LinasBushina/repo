.486
.model flat, stdcall
option casemap : none

include win32.inc

.data

endl equ <0dh, 0ah>

inputFilePath byte "XING_B24.bmp", 0
outputFilePath byte "XING_B24_out.bmp", 0

hInput dword ? ; дескрипторы ввода и вывода в файл
hStdOut dword ?
bytesWritten dword ?
header db 54 dup(0)
hOutputFILE dword ?
r db 1 dup(0) ; компоненты синий зеленый красный
g db 1 dup(0)
b db 1 dup(0)
fileSize dd 0
rnum real4 ?
rmul real4 0.299
gmul real4 0.587
bmul real4 0.114


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

	INVOKE ReadFile, hInput, addr header, 54, NULL, NULL
	INVOKE WriteFile, hOutputFILE, addr header, 54, NULL, NULL

	mov ecx, DWORD ptr[header+34]
	mov esi, ecx

	finit

	xor ecx, ecx
	.WHILE fileSize <= esi
		INVOKE ReadFile, hInput, addr r, 1, NULL, NULL
		INVOKE ReadFile, hInput, addr g, 1, NULL, NULL
		INVOKE ReadFile, hInput, addr b, 1, NULL, NULL
		inc fileSize
		inc fileSize
		inc fileSize

		xor eax, eax
		mov al, r
		mov rnum, eax
		fld rnum
		fmul rmul
		fstp rnum
		mov eax, rnum
		mov r, al

		xor eax, eax
		mov al, g
		mov rnum, eax
		fld rnum
		fmul gmul
		fstp rnum
		mov eax, rnum
		mov g, al

		xor eax, eax
		mov al, b
		mov rnum, eax
		fld rnum
		fmul bmul
		fstp rnum
		mov eax, rnum
		mov b, al

		xor eax, eax
		mov al, r
		add al, g
		add al, b
		mov r, al
		
		INVOKE WriteFile, hOutputFILE, addr r, 1, NULL, NULL
		INVOKE WriteFile, hOutputFILE, addr r, 1, NULL, NULL
		INVOKE WriteFile, hOutputFILE, addr r, 1, NULL, NULL
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
