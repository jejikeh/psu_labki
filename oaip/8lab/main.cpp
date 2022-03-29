#include <iostream>
#include <stdio.h>

//https://stackoverflow.com/questions/33804462/error-incompatible-types-in-assignment-of-char-to-char-20

struct node { 
    std::string data; // указатель на адрес data в памяти 
    node *next; // указатель на следующий
    node *prev; // указатель на преведущий
    
    node(std::string c,node *n, node *p){
        c.resize(20);data = c; next = n; prev = p; // data = c -> указатель получает значение "c[20]", resize  
    }
};

class deque {
    node *root; // Указатель на корневой узел
    node *end; // Указатель на конечный узел
    
    public:
    deque(std::string c_r, std::string c_e){ // конструктор дэка
        root = new node(c_r,nullptr,nullptr); // Самый первый узел
        end = new node(c_e,nullptr,root); // Самый правый узел
        root->next = end;
    }


    bool is_deque_empty(deque *d){ // если дэк кроме коревого и последнего больше не имеет узлов
        if(d->root->next == d->end){
            return true;
        } return false;
    }
    
    void insert_root_node(std::string data){ // Вставка после корня
        node *new_node = new node(data,root->next,root); // Новый узел вставляется после root
        root->next->prev = new_node; root->next = new_node; // Обновление указателей соседей
    }

    void insert_end_node(std::string data){ // Вставка до последнего корня
        node *new_node = new node(data,end,end->prev); // Новый узел, т.к он последний после него идет nullptr
        end->prev->next = new_node; end->prev = new_node; // перестановка new_node на end
    }

    void remove_root_node(deque *d){ 
        if(is_deque_empty(d)){
            return;
        }
        node* pntr = d->root->next;
        d->root->next = pntr->next;
        pntr->next->prev = d->root;
        delete pntr;
    }

    void remove_end_node(deque *d){
        if(is_deque_empty(d)){
            return;
        }
        node* pntr = d->end->prev;
        d->end->prev = pntr->prev;
        pntr->prev->next = d->end;
        delete pntr;
    }

    void done_deque(deque *d){
        while(!is_deque_empty(d)){
            remove_root_node(d);
        }
        delete d->root; delete d->end; 
    }

    void print_deque(){
        node * temp = root;
        while(temp){
            std::cout << temp->data << " "; temp = temp->next;
        }   
    }

};

int main(){
    std::string root_node;
    std::string end_node;
    std::cout << "Input a root node -> ";
    std::cin >> root_node;

    std::cout << "\nInput a end node -> ";
    std::cin >> end_node;

    deque* d = new deque(root_node,end_node);
    std::string str;
    int task = 0;
    while(task != -1){
        std::cout << "\nChoose task :\n1-Add left node\n2-Add right node\n3-Delete right node\n4-Delete left node\n5-Print all nodes\n6-Clean DSD\nInput a task number ->";
        std::cin >> task;
        switch(task){
            case 1:
                std::cout << "Input a node ->";
                std::cin >> str;
                std::cout << str;
                d->insert_root_node(str);
                break;
            case 2:
                std::cout << "Input a node ->";
                std::cin >> str;
                std::cout << str;
                d->insert_end_node(str);
                break;
            case 3:
                d->remove_end_node(d);
                break;
            case 4:
                d->remove_root_node(d);
                break;
            case 5:
                d->print_deque();
                break;
            case 6:
                d->done_deque(d);
                task = -1;
                break;
            default:
                break;
        }
    }
    main();
}