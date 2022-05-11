#include <iostream>
#include <stdio.h>

//https://stackoverflow.com/questions/33804462/error-incompatible-types-in-assignment-of-char-to-char-20

struct node { 
    float data; // указатель на адрес data в памяти 
    node *next; // указатель на следующий

    
    node(float c,node *n){
        data = c; next = n; // data = c -> указатель получает значение "c[20]", resize  
    }
};

class quene {
    node *root; // Указатель на корневой узел
    
    public:
    quene(float data ){ // конструктор дэка
        root = new node(data,nullptr); // Самый первый узел
    }
    node* get_last(node* temp){

        if(temp->next){
            get_last(temp->next);
        }else {
            return temp;
        }
    }

    void insert_node(float data){ // Вставка до последнего корня
        node* last = get_last(root);
        node* new_node = new node(data,nullptr);
        last->next = new_node; // Перестановка new_node на end. 
    }

    void remove_node(quene *d){
        node* new_root = root->next;
        delete root;
        root = new_root;
    }

    void print_quene(){
        node * temp = root;
        while(temp){
            std::cout << temp->data << " "; temp = temp->next;
        }   
    }

    void done_quene(quene* d){
        while(root){
            remove_node(d);
        }
        delete root;
    }

};

int main(){
    float root_node;
    float end_node;
    std::cout << "Input a root node -> ";
    std::cin >> root_node;
    quene* d = new quene(root_node);
    float data;
    int task = 0;
    while(task != -1){
        std::cout << "\nChoose task :\n1-Add node\n2-Remove node\n3-Print all nodes\n4-Clean DSD\nInput a task number ->";
        std::cin >> task;
        switch(task){
            case 1:
                std::cout << "Input a node ->";
                std::cin >> data;
                d->insert_node(data);
                break;
            case 2:
                d->remove_node(d);
                break;
            case 3:
                d->print_quene();
                break;
            case 4:
                d->done_quene(d);
                task = -1;
                break;
            default:
                break;
        }
    }
    main();
}