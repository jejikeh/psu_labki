#include <iostream>


int main();
struct list {
    int field; // данные
    struct list* next; // указатель на следующий элемент
    struct list* prev;
};


struct list* init(int a) {
    struct list* self; // указатель на новый элемент
    self = (struct list*)malloc(sizeof(struct list)); // выделение памяти под новый элемент
    self->field = a; // занесение значения в переменную field
    self->next = nullptr; // следующий элемент пустой
    self->prev = nullptr;
    return (self);
}

struct list* deleteRoot(list *root) {
    std::cout << root->field;
    struct list *temp;
    temp = root->next;
    temp->prev = nullptr;
    std::cout << temp->field;
    //std::cout << "\n ROOT : " << root->field;
    free(root);
    //std::cout << "\n ROOT : " << temp.field;
            

}

 void deleteElement(list* self) {
    struct list* prev, * next;
    prev = self->prev;
    next = self->next;
    if (self->prev == nullptr) {
        deleteRoot(self);
    }
    else if(self->next == nullptr) {
        self->prev->next = nullptr;
    }
    else {
        self->prev->next = self->next;
    }

    free(self);
}

struct list* addElement(list* self, int number) {
    struct list* temp, * p;
    temp = (struct list*)malloc(sizeof(struct list));
    p = self->next; // указатель на последний 
    self->next = temp; // замена последнего элемента на новый
    temp->field = number;
    temp->next = p;
    temp->prev = self;
    if (p != nullptr) {
        p->prev = temp;
    }
    return(temp);
}

void menu(list self);

struct list* filter(list* self) {
    int min = -50;
    int max = 50;

    struct list* temp;
    temp = self;
    do {
        if (temp->field > min && temp->field < max) temp = temp->next;
        else {
            deleteElement(temp);
            temp = temp->next;
            std::cout << "HEUI";
        }
    } while (temp != nullptr);

    return temp;
}


void printList(list* self) {
    struct list* temp;
    temp = self;
    do {
        printf("%d\n", temp->field);
        temp = temp->next;
    } while (temp != nullptr);
}


int main() {
    list numbers{};

    if (numbers.prev == nullptr) {
        int x;
        std::cout << "Input a root field: \n";
        std::cin >> x;
        numbers = *init(x);
        menu(numbers);
    }

}


void menu(list self) {
    std::cout << "\n 1 - add new element \n2 - remove and print \n0 - exit\n";
    int task;
    std::cin >> task;

    if (task == 1) {
        int x;
        std::cout << "Input a number: \n";
        std::cin >> x;
        addElement(&self, x);
    }
    else if (task == 2) {
        std::cout << "Filter list : \n";
    }
    else if (task == 0) {
        printList(&self);
    }
    else if (task == 5) {
        deleteRoot(&self);
    }
    menu(self);
}

