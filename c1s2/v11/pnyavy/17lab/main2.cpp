#include <iostream>
#include <list>
#include <time.h>
#include <vector>



// https://docs.microsoft.com/en-us/troubleshoot/developer/visualstudio/cpp/libraries/use-list-stl-function

// описываем список
typedef std::list<int, std::allocator<int> > LISTINT;

int findMin(std::vector<int> vectorint);
void display(std::vector<int> vectorint);
void sum_after_minus(std::vector<int> vectorint);
void sumInterval(std::vector<int> vectorint, int min, int max);

int main(){
    srand(time(0));
    

    // создаем пустой список
    std::vector<int> vectorint;


    // заполняем его рандомными значениями
    for(int k = 0; k < rand()%100; k++){
        vectorint.push_back(rand()%50-25);
    }

    display(vectorint);
    // выводи список с начала 

    std::cout << "\nIndex of min node : " << findMin(vectorint) << "\n";
    
    sum_after_minus(vectorint);
    sumInterval(vectorint,1,7);
}

void sumInterval(std::vector<int> vectorint, int min, int max){
    int sum = 0;
    for(const int& i : vectorint){
        if(i > min || i < max){
            sum += i;
        }
    }

    std::cout << "\nSum in interval: " << sum;
}

void sum_after_minus(std::vector<int> vectorint){
    int index = 0;
    for(const int& i : vectorint){
        index++;
        if(i < 0){
            break;
        }
    }

    int sum = 0;
    int newIndex = 0;
    for(const int& i : vectorint){
        newIndex++;
        if(newIndex >= index){
            sum += abs(i);
        }
    }

    std::cout << "\n Sum After minus : " << sum;
}


void display(std::vector<int> vectorint){
    for(const int& i : vectorint){
        std::cout << i << " ";
    }
}

// Функция нахождения минимального элемента
int findMin(std::vector<int> vectorint){
    int min;
    int index = 0;
    // каждый сравниваем с каждым
    for(const int& i : vectorint){
        for(const int& k : vectorint){
            if(min > std::min(i,k)){ 
                min = std::min(i,k);
            }
        }
    }
    for(const int& i : vectorint){
        index++;
        if(i == min){
            break;
        }
    }

    return index;
}