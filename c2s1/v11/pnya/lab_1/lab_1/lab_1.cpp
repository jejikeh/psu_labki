#include <iostream>

int Add(int x, int y);
int Sub(int x, int y);
int Mul(int x, int y);
int Div(int x, int y);

int main()
{
    int x = 2;
    int y = 3;
    std::cout << Add(x, y) << std::endl;
    return 0;
}

int Add(int x, int y) {
    __asm {
        mov eax, x;
        mov ebx, y;
        add eax, ebx;
        mov x, ebx;
    }

    return x;
}

int Sub(int x, int y) {
    __asm {
        mov eax, x;
        mov ebx, y;
        sub eax, ebx;
        mov x, eax;
    }

    return x;
}

int Mul(int x, int y) {
    __asm {
        mov eax, x;
        mov ebx, y;
        mul ebx;
        mov x, eax;
    }

    return x;
}

int Div(int x, int y) {
    __asm {
        mov eax, x;
        mov ecx, y;
        div ecx;
        mov x, eax;
    }

    return x;
}