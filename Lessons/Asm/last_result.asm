section .text

global _start

_start:
    mov eax, 3
    mov [strnum], eax
    mov eax, 2
    mov [count], eax
    
    st:
    mov ebx, 2
    
    cmp [strnum], ebx
    je is_prime
    
    is_prime:
    ;print
    mov     eax, [strnum]
    add     eax, '0'
    mov     [foo], eax
    mov     ecx, foo
    mov     edx, 1
    mov     ebx, 1
    mov     eax, 4
    int     0x80
    
    ;inc strnum
    mov eax, [strnum]
    inc eax
    mov [strnum], eax
    
    check:
    mov eax, [strnum]
    xor edx, edx
    div ebx ;module in edx

    cmp edx, 0
    je is_prime 
    jmp not_prime

    is_prime:
    mov eax, [strnum]
    inc eax
    mov [strnum], eax
    
    mov     eax, [strnum]
    add     eax, '0'
    mov     [foo], eax
    mov     ecx, foo
    mov     edx, 1
    mov     ebx, 1
    mov     eax, 4
    int     0x80
    
    mov     eax, '|'
    mov     [foo], eax
    mov     ecx, foo
    mov     edx, 1
    mov     ebx, 1
    mov     eax, 4
    int     0x80
    
    mov eax, [count]
    dec eax
    mov [count], eax
    cmp eax, 0
    je end

    not_prime:
    inc ebx
    
    cmp ebx, [strnum]
    jne check

    mov eax, [strnum]
    inc eax
    mov [strnum], eax
    jmp st

    end:
    mov     eax, 1
    int     0x80

section .data
    ;strnum dw 3
    ;count dw 2

segment .bss
    foo resb 1
    strnum resb 1
    count resb 1
