#include <iostream>
int main() {
    int n;
    char c;

    std::cout << "\n Input a string length : ";
    std::cin >> n;
    std::cout << " \n Input a char : ";
    std::cin >> c;

    if( n > 0 ){
        char string[n];
        for(int i = 0; i < n; i++){
            string[i] = c;
            std::cout << string[i];
        }
    }else {
        std::cout << "Wrong n";
        main();
    }
}
