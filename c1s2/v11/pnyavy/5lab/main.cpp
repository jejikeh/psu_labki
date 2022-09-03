#include <iostream>

struct MARSH {
    char name_start[30];
    char name_end  [30];
    int index;
};

int main() {
    MARSH marsh[8];
    for(int i = 0; i<8;i++){
        fflush(stdin);
        printf_s("MARSH index %i\n ", i+1);
        marsh[i].index = i+1;
        printf_s("\nMARSH name_start:  ");
        gets(marsh[i].name_start);
        printf_s("\nMARSH name_end:  ");
        gets(marsh[i].name_end);
    }

    char x[30];
    printf_s("Enter a marsh : ");
    gets(x);
    std::cout << x;
    for(int i = 0; i < 8; i++){
        std::cout << marsh[i].name_start;
        if(marsh[i].name_start == x) {
            //std::cout << "\n" << marsh[i].name_start << "\n" << marsh[i].name_end << "\n" << marsh[i].index;
        } else {
            //std::cout << "\n Error";
        }
    }
}
