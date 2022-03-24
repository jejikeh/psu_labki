#include <iostream>


struct node {
    float data;
    node *forward;
    node *back;
};

struct double_linked_list {
    node *start;
    node *end;
    node *pointer;
};

void initList(double_linked_list *DLL){
    // выделение памяти для правого фиктивного элемента
    DLL->start = (node *) malloc(sizeof(node));
    // элемент, следующий за левым фиктивным - правый фиктивный элемент
    DLL->start->forward = DLL->end;
    // элемент, предшествующий первому - последний элемент
    DLL->start->back = DLL->end;
    //  элемент, идущий после последнего элемента - первый элемент
    DLL->end->forward = DLL->start;
    // элемент, предшествующий правому фиктивному - левый фиктивный элемент 
    DLL->end->back = DLL->start;

    DLL->pointer = DLL->start;
}

void insertPredNode(double_linked_list *DLL, float data){
    node *newNode = (node *)malloc(sizeof(node));
    newNode->data = data;
    newNode->forward = DLL->pointer;
    newNode->back = DLL->pointer->back;
    DLL->pointer->back = newNode;
    DLL->pointer->forward = newNode;
}

void insertPostNode(double_linked_list *DLL, float data){
    node *newNode = (node *)malloc(sizeof(node));
    newNode->data = data;
    newNode->forward = DLL->pointer->forward;
    newNode->back = DLL->pointer;
    DLL->pointer->back = newNode;
    DLL->pointer->forward = newNode;
}

void printList(double_linked_list *DLL){
    node *temp;
    temp = DLL->start->forward;
    while(temp != DLL->end){
        std::cout << temp->data << " ";
        temp = temp->forward;
    }
}

int main(){
    double_linked_list *DDL = (double_linked_list*)malloc(0);
    initList(DDL);
    insertPostNode(DDL,1);
    insertPostNode(DDL,1);
    insertPostNode(DDL,1);

    printList(DDL);
}



