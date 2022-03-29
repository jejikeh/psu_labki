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
};

int main(){
    linked_list* list = new linked_list();
    list->insert_root_node(1);
    list->insert_last_node(3);
    list->insert_root_node(2);
    list->print_list();
}