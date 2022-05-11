#include <iostream>

struct MARSH {
    std::string name_start;
    std::string name_end;
    int index;
};

int main() {
    MARSH marsh[8];
    for(int i = 0; i<8;i++){
        fflush(stdin);
        printf_s("MARSH index %i\n ", i+1);
        marsh[i].index = i+1;
        printf_s("\nMARSH name_start:  ");
        std::cin >> marsh[i].name_start;
        printf_s("\nMARSH name_end:  ");
        std::cin >> marsh[i].name_end;
    }

    std::string x;
    printf_s("Enter a marsh : ");
    std::cin >> x;
    //std::cout << x;
    for(int i = 0; i < 8; i++){
        //std::cout << marsh[i].name_start;
        if(marsh[i].name_start == x || marsh[i].name_end == x  ) {
            std::cout << "\n" << marsh[i].name_start << "\n" << marsh[i].name_end << "\n" << marsh[i].index;
        } else {
            std::cout << "\n Error";
        }
    }
}
