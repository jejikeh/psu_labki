#include <iostream>
#include <queue>
#include <windows.h>

using namespace std;

void task1();

void task2();

void task3();

struct node {
    int value;
    int prior;
    node *next;


    // Конструктор для очереди с приоритетом
    node(int v, int p, node *n){
        value = v;
        prior = p;
        next = n;
    }

    // Конструктор для очереди с без приоритета
    node(int v, node *n){
        value = v;
        next = n;
        prior = -1;
    }

    set_next(node *n){
        next = n;
    }

};

struct queuep {
    node *root;

    // Конструктор для очереди без приоритетом
    queuep(int v){
        root = new node(v,nullptr);
    }

    // Конструктор для очереди с приоритетом
    queuep(int v,int p){
        root = new node(v,p,nullptr);
    }



    node* get_biggest_node_prior(int m){

        node *temp = root;
        node *biggest_prior = new node(-1,0,nullptr);

        while(temp != nullptr){
            
            while(temp->prior > biggest_prior->prior){
                biggest_prior = temp;
                temp = temp->next;
            }

            temp = temp->next;
        }

        remove(biggest_prior->value);
        
        return biggest_prior;
    }


    // Вставка без приоритета
    insert(int v){
        node *temp = root;

        while(temp->next != nullptr){
            temp = temp->next;
        }
        
        temp->next = new node(v,nullptr);

    }

    // Вставка c приоритетом
    insert(int v, int p){
        node *temp = root;

        while(temp->next != nullptr){
            temp = temp->next;
        }
        
        temp->next = new node(v,p,nullptr);

    }

    print(){
        node *temp = root;

        if(root->prior == -1){
            while(temp != nullptr){
                std::cout << temp->value << " ";
                temp = temp->next;
            }
        } else {
            node* t = get_biggest_node_prior(INT16_MAX);
            while(temp != nullptr){

                std::cout << t->value << " ";
                t = get_biggest_node_prior(t->prior);
                temp = temp->next;
            }
        }
        
    }

    int remove(int v){
        node *temp = root;
        
        if(v == root->value){
            root = temp->next;
            root->next = temp->next->next;
            return 0;
        }

        while(temp->next != nullptr){
            if(temp->next->value == v){
                temp->next = temp->next->next;
                return 0;
            }else{
                temp =temp->next;
            }
        }

        return 0;

    }

    is_empty(){
        if(root == nullptr){
            std::cout << "\nqueue is empty";
        }else {
            std::cout << "\nqueue is not empty";
        }
    }
};


/*
//Функция инициализации очереди через массив
void init(struct queuep *q) {//Инициализация очереди
    
}

void insert(struct queuep *q, int p, int x) {
    if (q->rear < 99) {
        q->rear++;
        q->qu[p].value = x;
    } else
        printf("Очередь полна!\n");
    return;
}

int isempty(struct queuep *q) {
    if (q->rear < q->frnt) return 1;
    else return 0;
}

void print(struct queuep *q) {
    int h;
    if (isempty(q) == 1) {
        printf("Очередь пуста!\n");
        return;
    }
    for (h = q->frnt; h <= q->rear; h++)
        printf("%d ", q->qu[h].value);
    return;
}

int remove(struct queuep *q, int p) {
    int x, h;
    if (isempty(q) == 1) {
        printf("Очередь пуста!\n");
        return 0;
    }
    x = q->qu[q->frnt];
    for (h = q->frnt; h < q->rear; h++) {
        q->qu[h] = q->qu[h + 1];
    }
    q->rear;
    return x;
} */

int main() {
    queuep* q = new queuep(2,2);
    
    q->insert(4,5);
    q->insert(6,1);
    q->insert(78,6);

    q->insert(57,3);
    
    //q->remove(4);

    q->print();
}

/*
void task1() {
    SetConsoleOutputCP(CP_UTF8);
    queue<int> que;
    int n;
    cout << "Количество элементов: ";
    cin >> n;
    for (int i = 0; i < n; i++) {
        int el;
        cout << "Введите элемент " << i + 1 << ": ";
        cin >> el;
        que.push(el);
    }
    cout << endl;
    int tmp;
    tmp = que.front();
    que.front() = que.back();
    que.back() = tmp;
    while (!que.empty()) {
        int v = que.front();
        que.pop();
        cout << v << " ";
    }
    cout << endl;

    main();
}

void task2() {
    SetConsoleOutputCP(CP_UTF8);
    struct queuep *q;
    int a, n, p;
    q = (queuep *) malloc(sizeof(queuep));
    init(q);
    print(q);
    cout << "Количество: ";
    cin >> n;
    for (int i = 0; i < n; i++) {
        printf("Введите элемент очереди: ");
        scanf("%d", &a);
        printf("Введите приоритет элемента : ");
        scanf("%d", &p);
        insert(q, a, p);
    }
    printf("\n");
    print(q);

    int p1;
    printf("Введите приоритет элемента: ");
    scanf("%d", p1);
    remove(q, p1);
    printf("\n");
    print(q);

}

void task3() {
    SetConsoleOutputCP(CP_UTF8);
    priority_queue<int> index;
    priority_queue<int> pq;

    int n;
    cout << "Количество элементов: ";
    cin >> n;
    for (int i = 0; i < n; i++) {
        int el;
        cout << "Введите элемент " << i + 1 << ": ";
        cin >> el;
        pq.push(el);
    }
    while (!pq.empty()) {
        int v = pq.top();
        pq.pop();
        cout << v << " ";
    }

    main();
}
*/