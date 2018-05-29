.486
.model flat, stdcall
option casemap : none

include win32.inc

.data

endl equ <0dh, 0ah>

inputFilePath byte "test.bmp", 0

hInput dword ?
hStdOut dword ?
bytesWritten dword ?

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

	invoke CreateFileA,
		addr inputFilePath,
		GENERIC_READ, DO_NOT_SHARE, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL
	.if eax == INVALID_HANDLE_VALUE
		invoke handleError, addr sFailedToOpenInputFile, sFailedToOpenInputFileLength
	.endif
	mov hInput, eax

	invoke CloseHandle, hInput
	.if eax == FALSE
		invoke handleError, addr sFailedToCloseHandle, sFailedToCloseHandleLength
	.endif

fatal_error:
	invoke ExitProcess, 0
main endp

end main
