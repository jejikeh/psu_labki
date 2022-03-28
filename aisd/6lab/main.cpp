#include <iostream>


// стркуктура узла
struct node {
    int data;
    unsigned char height;
    node* left;
    node* right;
    node(int n_data) {
        data = n_data;
        left = right = 0;
        height = 1;
    }
};

// Возвращает height узла если он существует
unsigned char height(node *p_node){
    return p_node ? p_node->height : 0;
}

// Возвращает фактор баланса между левым и правым
int balance_factor(node *p_node){
    return height(p_node->right) - height(p_node->left);
}

// Исправляет высоту 
void fix_height(node *p_node){
    unsigned char height_left = height(p_node->left);
    unsigned char height_right = height(p_node->right);
    p_node->height = (height_left > height_right ? height_left : height_right) + 1;
}

// Меняе узлы местами -> малый поворот
node* rotate_right(node *p_node){
    node *temp_node = p_node->left;
    p_node->left = temp_node->right;
    temp_node->right = p_node;
    fix_height(p_node);
    fix_height(temp_node); 
    return temp_node;
}

// Меняе узлы местами -> малый поворот
node* rotate_left(node *p_node){
    node *temp_node = p_node->right;
    p_node->right = temp_node->left;
    temp_node->left = p_node;
    fix_height(p_node);
    fix_height(temp_node); 
    return temp_node;
}


// Большие повороты
node* balance(node *p_node){
    fix_height(p_node);
    if(balance_factor(p_node) == 2){
        if ( balance_factor(p_node->right) < 0){
            p_node->right = rotate_right(p_node->right);
        }
        return rotate_left(p_node);
    }
    if(balance_factor(p_node) == -2 ){
        if(balance_factor(p_node->left) > 0){
            p_node->left = rotate_left(p_node->left);
        }
        return rotate_right(p_node);
    }
    return p_node;
}

// Добавление узла
node* insert(node *p_node,int data){
    if(!p_node) return new node(data);
    if(data < p_node->data){
        p_node->left = insert(p_node->left,data);
    }else {
        p_node->right = insert(p_node->right,data);
    }
    return balance(p_node);
}

void in_order(node *p_node){
    if(p_node){
        in_order(p_node->left);
        std::cout << p_node->data << "\t";
        in_order(p_node->right);
    }
}
void in_preorder(node *p_node){
    if(p_node){
        std::cout << p_node->data << "\t";
        in_preorder(p_node->left);
        in_preorder(p_node->right);
    }
}

void in_postorder(node *p_node){
    if(p_node){
        in_postorder(p_node->left);
        in_postorder(p_node->right);
        std::cout << p_node->data << "\t";
    }
}

node* findmin(node* p) // поиск узла с минимальным ключом в дереве p 
{
	return p->left?findmin(p->left):p;
}

node* removemin(node* p) // удаление узла с минимальным ключом из дерева p
{
	if( p->left==0 )
		return p->right;
	p->left = removemin(p->left);
	return balance(p);
}


// Идем влево до упора что-бы найти минимальное
node* find_min(node* p_node){
    if(!p_node){
        std::cout << "No node";
        return(p_node);
    }else {
        while(p_node->left != NULL){
            p_node = p_node->left;
        }
        return p_node;
    }
}

// Идем вправо до упора что-бы найти максимальное
node* find_max(node* p_node){
    if(!p_node){
        std::cout << "No node";
        return(p_node);
    }else {
        while(p_node->right != NULL){
            p_node = p_node->right;
        }
        return p_node;
    }
}

node* remove_node(node* p_node, int data){
    if(!p_node) return 0;
    if(data < p_node->data){
        p_node->left = remove_node(p_node->left,data);
    }else if( data > p_node->data){
        p_node->right = remove_node(p_node->right,data);
    }else {
        node* q = p_node->left;
        node* r = p_node->right;
        delete p_node;
        if(!r) return q;
        node* min = findmin(r);
        min->right = removemin(r);
        min->left = q;
        return balance(min);
    }
    return balance(p_node);
}

int main(){
    int task = 0;
    int x = 0;
    std::cout << "Root -> ";
    std::cin >> x;
    node *root = new node(x);
    while(task != -1){
        std::cout << "1-Add node\n2-Delete node\n3-Print list\n4-Find min and max\nTask -> ";
        std::cin >> task;
        switch (task)
        {
        case 1:
            std::cout << "\nAdd node -> ";
            std::cin >> x;
            insert(root, x);
            break;
        case 2:
            std::cin >> x;
            remove_node(root,x);
            std::cout << "\n";
            break;
        case 3:
            std::cout << "\nIN_ORDER ->\n";
            in_order(root);

            std::cout << "\nIN_POSTORDER ->\n";
            in_postorder(root);


            std::cout << "\nIN_PREORDER ->\n";
            in_preorder(root);
            std::cout << "\n";
            break;
        case 4:
            std::cout << "MIN -> "<<  find_min(root)->data;
            std::cout << "\n";
            std::cout << "MAX -> "<<  find_max(root)->data;
            std::cout << "\n";
            break;
        default:
            break;
        }
    }
}