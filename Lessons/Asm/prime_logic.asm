section .text

global _start

_start:
    mov ebx, 2
    check:
    mov eax, [strnum]
    xor edx, edx
    div ebx ;module in edx

    cmp edx, 0
    jeq is_prime 
    jmp not_prime

    is_prime:
    inc [strnum]
    print [strnum]
    dec [count]
    cmp [count], 0
    jeq end

    not_prime:
    inc ebx
    cmp ebx, [strnum]
    jne check

    inc [strnum]
    jmp _start

    end:
    ret


section .data
    strnum dw 9
    count dw 3
