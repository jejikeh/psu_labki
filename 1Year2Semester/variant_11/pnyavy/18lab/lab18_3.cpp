#include <iostream>
#include <vector>

using namespace std;
 
struct Node {
    char number; //данные
    Node *next; //указатель на следующий узел
    Node *prev; //указатель на предыдущий
};
 
class doubleList {
    Node *head;
    Node *tail;
public:
    doubleList();
    doubleList(doubleList *list);
    void addFirst(char number);
    void addLast(char number);
    void delTail();
    void delHead();
    void sortingList();
    void swap(char &a, char &b);
    void showList(string name) const;


    bool operator == (doubleList list1)
    {
        if(head != list1.head || tail != list1.tail) return false;
        return true;
    }

    doubleList operator + (doubleList list)
    {
        doubleList res;
        if (this->head)
        {
            Node *buf = this->head;
            while (buf) {
                cout << buf->number << " ";
                res.addLast(buf->number);
                buf = buf -> next;
            }
        }
        if (list.head)
        {
            Node *buf = list.head;
            while (buf) {
                cout << buf->number << " ";
                res.addLast(buf->number);
                buf = buf -> next;
            }
        }
        return res;
    }

    doubleList operator += (int numb)
    {
        addLast(numb);
        return *this;
    }
 

    doubleList operator = (doubleList *list)
    {
        doubleList res = list;
        return res;
    }

    void operator [] (doubleList *list);
};
 
doubleList :: doubleList() {
    head = tail = NULL;
}

doubleList :: doubleList(doubleList *list) {
    head = list->head;
    tail = list->tail;
}
 
//Добавление узла в начало
void doubleList :: addFirst(char number) {
    Node *buf  = new Node;
    buf -> number = number;
    if (!head) {
        buf -> next = tail;
        tail = buf;
    }
    else {
        buf -> next = head;
        head -> prev = buf;
    }
    head = buf;
    head -> prev = NULL;
 
}
 
//Добавление узла в начало
void doubleList :: addLast(char number) {
    Node *buf = new Node;
    buf -> number = number;
    if (!head) {
        buf -> next = tail;
        head = buf;
        buf -> prev = NULL;
    }
    else {
        buf -> next = tail -> next;
        buf -> prev = tail;
        tail -> next = buf;
    }
    tail = buf;
}
 
//Пройти по списку и вывести все элементы
void doubleList :: showList(string name) const {
    if (head) {
        cout << "\n~-~-~-~- Вывод " << name << " ~-~-~-~-\n";
        Node *buf = head;
        while (buf) {
            cout << buf ->number << " ";
            buf = buf -> next;
        }
        cout << endl;
    }
    else cout << "List is empty " << endl;
}
 
//Удаление головы
void doubleList :: delHead() {
    if (head) {
        Node *buf = head;
        head = head -> next;
        head -> prev = NULL;
        delete buf;
    }
    else cout << "List is empty" << endl;
}
 
//Удаление хвоста
void doubleList :: delTail() {
    if (tail) {
        Node *buf = tail;
        tail = tail -> prev;
        tail -> next = NULL;
        delete buf;
    }
    else cout << "List is empty" << endl;
}
 
//Обмен данных списка
void doubleList :: swap(char &a, char &b) {
    char buf = a;
    a = b;
    b = buf;
}
 
//Сортировка
void doubleList :: sortingList() {
    Node *buf = head;
    for (Node *i = buf; i; i = i -> next) {
        for (Node *j = i -> next; j; j = j -> next) {
            if (i -> number < j -> number) {
                swap(i -> number, j -> number);
            }
        }
    }
 
}
 
 
int main()
{
    doubleList ob;

    int n;
    cout << "Введите кол-во элементов: " << endl;
    cin >> n;

    char numb = 0;
    for (int i = 0; i < n; i++)
    {
        cin >> numb;
        ob.addFirst(numb);
    }
    
    // while (1) {
    //     cin >> a_i;
    //     if (a_i) {
    //         ob.addFirst(a_i);
    //     }
    //     else break;
    // }
    // ob.sortingList();
    ob.showList("ob");

    doubleList ob1;
    if(ob1 == ob) cout << "equal\n";
    else cout << "no equal\n";

    ob1 = ob;
    ob1.showList("ob1");
    ob1 += 5;
    ob1.showList("ob1");

    doubleList ob2;

    ob2 = ob1+ob;
    ob2.showList("ob2");
    return 0;
}