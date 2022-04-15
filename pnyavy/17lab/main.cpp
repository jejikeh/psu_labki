#include <iostream>
#include <list>
#include <time.h>



// https://docs.microsoft.com/en-us/troubleshoot/developer/visualstudio/cpp/libraries/use-list-stl-function

// описываем список
typedef std::list<int, std::allocator<int> > LISTINT;


int findMin(LISTINT listint, LISTINT::iterator i);
void display(LISTINT listint, LISTINT::iterator i);
int findNodeIndex(LISTINT listint, LISTINT::iterator i, int node);
void findNodesBigger(LISTINT listint, LISTINT::iterator i, int node);



int main(){
    srand(time(0));
    

    // создаем пустой список
    LISTINT listint;
    LISTINT::iterator i;

    // заполняем его рандомными значениями
    for(int k = 0; k < rand()%100; k++){
        listint.push_back(rand()%100);
    }

    display(listint, i);
    // выводи список с начала 

    std::cout << "\nMin node : " << findMin(listint,i) << "\n";
    
    int findNode;
    std::cout << "\nInput a find node : ";
    std::cin >> findNode;
    std::cout << "Index of node : " << findNodeIndex(listint,i, findNode);

    int findNodeBigger;
    std::cout << "\nInput a find bigger nodes : ";
    std::cin >> findNodeBigger;
    findNodesBigger(listint,i, findNodeBigger);
    

    std::cout << "\nSortint list...... \n";
    listint.sort();
    display(listint, i);

    std::cout << "\nInput a length nodes to delete : ";
    int length;
    std::cin >> length;
    std::cout << "\nInput a node to delete after : ";
    int nodeA;
    std::cin >> nodeA;

    
}



void display(LISTINT listint, LISTINT::iterator i){
    for(i = listint.begin(); i != listint.end(); ++i){
        std::cout << *i << " ";
    }
}

// Функция нахождения минимального элемента
int findMin(LISTINT listint, LISTINT::iterator i){
    int min;
    // каждый сравниваем с каждым
    for(i = listint.begin(); i != listint.end(); ++i){
        LISTINT::iterator k;

        for(k = listint.begin(); k != listint.end(); ++k){
            if(min > std::min(*i,*k)){ 
                min = std::min(*i,*k);
            }
        }
    }

    return min;
}

int findNodeIndex(LISTINT listint, LISTINT::iterator i, int node){
    int index = -1;
    int l = -1;
    // каждый сравниваем с каждым
    for(i = listint.begin(); i != listint.end(); ++i){
        if(*i == node){
            index++;
            break;
        }else {
            index++;
        }
    }

    return index;

}

void findNodesBigger(LISTINT listint, LISTINT::iterator i, int node){
    // каждый сравниваем с каждым
    for(i = listint.begin(); i != listint.end(); ++i){
        if(*i > node){
            std::cout << *i << " ";
        }
    }
}