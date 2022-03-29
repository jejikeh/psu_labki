#include <iostream>
struct node { float data; node *next; node(float c_data,node *c_next){data = c_data; next = c_next;}};
class linked_list {
    node *root; // указатель на последний и корневой элемент;
    public:
    linked_list(){ root = new node(0,root);} // при инициализации линейного кольцевого списка указываем указатель на корень 
    node* get_last(node* temp){
        return temp->next != root ? get_last(temp->next) : temp;
    }
    void insert_root_node(float data) { // Вставка элемента сначала, меняем корневой элемент на новый
        node* new_node = new node(data,root); // Создаем новый корень.
        node *last_node = get_last(root); // Ищем последний элемент.
        root = new_node; // Меняем корень списка  на новый узел
        last_node->next = root; // 
    }
    void insert_last_node(float data) {
        node* new_node = new node(data,root); // Создаем новый корень.
        node *last_node = get_last(root); // Ищем последний элемент.
        last_node->next = new_node; // теперь последний элемент это новый узел
    }
    void print_list(){
        node* temp = root;
        do { std::cout << temp->data << " "; temp = temp->next; } while (temp  != root); // До тех пор пока следуюший элемент снова не будет корнем
    }
    void remove_node(float data){
        if(root->data == data){ // Если удаляемый элемент корневой
            node *p_l = get_last(root); // Последний
            node *t = root->next;
            delete root;
            root = t; // теперь корневой это тот, который шел после корневого
            p_l->next = t;
            return;
        }
        
        node* temp = root;
        while(temp->next != root){
            if(temp->next->data == data){ // Если следующий элемент равен искомому
                node *ptr = temp->next->next;
                delete temp->next;
                temp->next = ptr;
                return;
            }
            temp = temp->next;
        }
        std::cout << "Value not foun" << std::endl;
    }
};

int main(){
    linked_list* list = new linked_list();
    list->insert_root_node(2);
    list->insert_last_node(3);
    list->insert_last_node(8);
    list->insert_last_node(6);
    list->insert_root_node(12);
    list->insert_root_node(123);
    list->remove_node(6);
    list->print_list();
    delete list;
}