#include <iostream>

struct list{
    int field; // данные
    struct list *next; // указатель на следующий элемент
    struct list *prev;
};


struct list *init(int a){
    struct list *self; // указатель на новый элемент
    self = (struct list*) malloc(sizeof (struct list)); // выделение памяти под новый элемент
    self->field = a; // занесение значения в переменную field
    self->next = nullptr; // следующий элемент пустой
    self->prev = nullptr;
    return (self);
}

struct list *deleteRoot(list *root){
    struct list *temp;
    temp = root->next;
    temp->prev = nullptr;
    free(root);
    return(temp);
}

struct list *deleteElement(list *self){
    struct list  *prev, *next;
    prev = self->prev;
    next = self->next;
    if(prev != nullptr) {
        prev->next = next;
    }
    if(next != nullptr) {
        next->prev = prev;
    }
    return(prev);
}

struct list *addElement(list *self, int number){
    struct list *temp, *p;
    temp = (struct list*) malloc(sizeof(struct list));
    p = self->next; // указатель на последний элемент
    self->next = temp; // замена последнего элемента на новый
    temp->field = number;
    temp->next = p;
    temp->prev = self;
    if( p != nullptr) p->prev = temp;
    return(temp);
}

void menu(list self);

struct list * filter(list *self) {
    int min = -50;
    int max = 50;

    struct list *temp;
    temp = self;
    do {
        if (temp->field > min && temp->field < max) temp=temp->next;
        else {
            temp = self->prev;
            temp->next = self->next;
        }
    } while (temp != nullptr);

    return temp->prev;
}


void printList(list *self){
    struct list *temp;
    temp = self;
    do {
        printf("%d\n",temp->field);
        temp = temp->next;
    } while ( temp != nullptr);
}


int main() {
    list numbers{};

    if(numbers.prev == nullptr){
        int x;
        std::cout << "Input a root field: \n";
        std::cin >> x;
        numbers = *init(x);
        menu(numbers);
    } else {
        std::cout << "FUCK \n";
    }

}


void menu(list self){
    std::cout << "1 - add new element \n2 - remove and print \n0 - exit";
    int task;
    std::cin >> task;

    if(task == 1){
        int x;
        std::cout << "Input a number: \n";
        std::cin >> x;
        addElement(&self,x);
    }else if (task == 2){
        std::cout << "Filter list : \n";
        filter(&self);
    }else if (task == 0){
        printList(&self);
        std::exit(0);
    }
    menu(self);
}

