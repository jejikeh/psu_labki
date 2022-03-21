#include <iostream>

int fib(int x){
    if(x <= 1){
        return x;
    }else {
        return fib(x - 1) + fib(x - 2);
    }
}

double fact(int x){
    if(x != 0){
        return x * fact(x - 1);
    }else {
        return 1;
    }
}

int posled(int x){
    if(x > 1){
        return x - posled(posled(x - 1));
    }else {
        return 1;
    }
}

int NOD(int x, int y){
    if(x < y) return NOD(y,x);
    if(y == 0) return x;
    return NOD(y, x % y);
}

int lej(int x,int n){
    if (n > 1){
        return ((2*n - 1) * lej(x,n-1) - (n - 1)*lej(x,n-2))/n;
    }
}

int razn(int x){
    if (x > 2) return razn(x%2) + razn(x%3);
    else return x;
}

int A(int n, int x){
    if(n == 0){
        return x + 1;
    }
    else {
        if ((n != 0) && (x == 0)){
            return A(n - 1, 1);
        }
        else {
            return A(n - 1, A(n, x - 1));
        }
    }
}

int main(){ 
    int x,y,n;
    std::cout << "X -> ";
    std::cin >> x;
    std::cout << "Fibonachi -> "<<  fib(x) << std::endl;
    std::cout << "Factorial -> "<<  fact(x) << std::endl;

    std::cout << "Posledovatelnost -> " << posled(x) << std::endl;
    std::cout << "Y -> ";
    std::cin >> y;
    std::cout << "NOD -> "<< NOD(x,y) << std::endl;

    std::cout << "N -> ";
    std::cin >> n;
    std::cout << "Lejandr -> "<< NOD(x,n) << std::endl;
    std::cout << "Akkerman -> "<< A(n,x) << std::endl;

    std::cout << "Raznastoronya raznost -> "<< razn(x) << std::endl;


}