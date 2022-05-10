#include <iostream>
#include <cstring>

int main(){
    int n;
    std::cout << "Input a length of string : ";
    std::cin >> n;

    char *str = (char *) malloc(n * sizeof(char));

    for(int i = 0; i < n; i++){
        std::cin >> str[i];
    }

    for(int index = n; index > n - 6; index--){
        str[index] = ' ';
    }
    
    n = n - 6;

    int m;
    std::cout << " How many * add : ";
    std::cin >> m;
    for(int index = n+1; index < n + m + 1; index++){
        str[index] = '*';
    }

    std::cout << str;
    
    
}