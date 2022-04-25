#include <iostream>
struct node { 
    float data; 
    node *next; 
    node *prev;
    node(float _data,node *_next,node *_prev){
        data = _data; 
        next = _next;
        prev = _prev;
    }
};
class double_linked_list {
    node *root; // указатель на последний и корневой элемент;
    public:
    double_linked_list(){ 
        root = new node(NULL,nullptr,nullptr);
    } // при инициализации линейного кольцевого списка указываем указатель на корень 
    node* get_last(node* temp){
        return temp->next != nullptr ? get_last(temp->next) : temp;
    }
    void insert_root_node(float data) { // Вставка элемента сначала, меняем корневой элемент на новый
        if(root->data == NULL){
            root->data = data;
        }else {
            node* new_node = new node(data,root,nullptr); // Создаем новый корень.
            root->prev = new_node;
            root = new_node; // Меняем корень списка  на новый узел
        }
    }
    void insert_last_node(float data) {
        if(root->data == NULL){
            root->data = data;
        }else {
            node* new_node = new node(data,nullptr,get_last(root)); // Создаем новый корень.
            get_last(root)->next = new_node; // теперь последний элемент это новый узел
        }
    }
    void print_list(){
        node* temp = root;
        do { 
            std::cout << temp->data << " "; 
            temp = temp->next; 
        } while (temp  != nullptr); // До тех пор пока следуюший элемент снова не будет корнем
    }

    void insert_at(float index,float data){
        node* temp = root;
        while(temp->next != nullptr){
            if(temp->data == index){
                node* new_node = new node(data,temp->next,temp);
                temp->next->prev = new_node;
                temp->next = new_node;
                return;
            }
            temp = temp->next;
        }
        insert_last_node(data);
    }

    void remove_node(float data){
        if(root->data == data){ // Если удаляемый элемент корневой
            node *temp = root->next;
            delete root;
            root = temp; // теперь корневой это тот, который шел после корневого
            root->prev = nullptr;
            return;
        }
        
        node* temp = root;
        while(temp->next != nullptr){
            if(temp->next->data == data){ // Если следующий элемент равен искомому
                if(temp->next->next == nullptr){ // если искомый элемент последний
                    temp->next = nullptr;
                    //delete temp->next;
                    return;
                }else {
                    node *ptr = temp->next->next;
                    delete temp->next;
                    temp->next = ptr;
                    ptr->prev = temp;
                    return;
                }
            }
            temp = temp->next;
        }
        std::cout << "Value not found" << std::endl;
    }
};

int main(){
    double_linked_list* list = new double_linked_list();

    list->insert_root_node(2);

    list->insert_last_node(3);
    list->insert_last_node(8);
    list->insert_last_node(6);

    list->insert_root_node(12);
    list->insert_root_node(123);


    list->remove_node(2);

    list->insert_at(123,234);

    list->print_list();
    delete list;
}