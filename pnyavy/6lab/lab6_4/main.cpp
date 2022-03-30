#include <iostream>


int main() {
    std::string string;
    std::string abc;
    std::cin >> string;
    for(int i = 0; i < string.length();i++) {
        if (int(string[i] >= 97 && int(string[i]) <= 122)) {
            abc = abc + string[i];
        }
    }
    int x = abc[0];
    int i = 0;
    while(x - int(abc[i]) == -1 or x - int(abc[i]) == 0){
        x = abc[i];
        i++;
        std::cout << false;
    }


}
