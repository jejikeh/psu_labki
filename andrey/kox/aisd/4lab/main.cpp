#include <iostream>
#include <vector>

using namespace std;

template <typename T>
class binTree
{

public:
    T value;
    binTree* left; 
    binTree* right; 
};


template <typename T>
binTree<T>* getmin(binTree<T>* Tree, binTree<T>*& prev)
{
    if (Tree == NULL)
    {
        return NULL;
    }
    if (Tree->left != NULL)
    {
        binTree<T>* tmp = getmin(Tree->left, Tree);
        prev = Tree;
        return tmp;
    }
    else
    {
        return Tree;
    }
}

template <typename T>
void deleteElement(binTree<T>* tree, T b, binTree<T>* prev = NULL)
{
    if (tree != NULL)
    {
        if (b == tree->value)
        {
            if ((tree->left == NULL) && (tree->right == NULL))
            {
                if (prev != NULL && prev->value <= tree->value)
                    prev->right = NULL;
                else
                    prev->left = NULL;
                delete tree;
            }
            else if (tree->left == NULL && tree->right != NULL)
            {
                if (prev != NULL && prev->value <= tree->value)
                    prev->right = tree->right;
                else
                    prev->left = tree->right;
                delete tree;
            }
            else if (tree->left != NULL && tree->right == NULL) {
                if (prev != NULL && prev->value <= tree->value)
                    prev->right = tree->left;
                else
                    prev->left = tree->left;
                delete tree;

            }
            else if (tree->left != NULL && tree->right != NULL)
            {
                binTree<T>* prev = NULL;
                binTree<T>* ptr = getmin(tree->right, prev);
                if (ptr->right == NULL) {
                    if (prev != NULL)
                        prev->left = NULL;
                }
                else {
                    if (prev != NULL)
                        prev->left = ptr->right;
                }
                tree->value = ptr->value;
                delete ptr;
            }

        }
        else if (b < tree->value)  //   c ������� 1 � 2 if ���� ����� 
            //����� ������ ���� �� ������ ������ ������� � �� ������� ����������� �������
        {
            deleteElement(tree->left, b, tree); // �������� 
        }
        else if (b > tree->value)
        {
            deleteElement(tree->right, b, tree); // ��������
        }
    }
    else
    {
        cout << "������� �� ������!" << endl;
    }
}

// �����
template <typename T>
void findInTree(binTree<T>* Tree, T a)
{
    if (Tree != NULL)
    {
        if (Tree->value == a)
        {
            cout << "������� ������!" << endl;
            return;
        }
        else if (a < Tree->value)
        {
            findInTree(Tree->left, a);
        }
        else if (a > Tree->value)
        {
            findInTree(Tree->right, a);
        }

    }
    else
    {
        cout << "������� �� ������!" << endl;
    }
}

// ����� ���
template <typename T>
void detourPKL(binTree<T>* Tree)
{
    if (Tree != NULL)
    {
        detourPKL(Tree->right);
        cout << Tree->value << "\t";
        detourPKL(Tree->left);
    }
}

// ����� ���
template <typename T>
void detourKLP(binTree<T>* tree)
{
    if (tree != NULL)
    {
        cout << tree->value << "\t";
        detourKLP(tree->left);
        detourKLP(tree->right);
    }
}

// ������� ��������
template <typename T>
void insert(binTree<T>*& tree, T k)
{
    if (tree == NULL)
    {
        tree = new binTree<T>;
        tree->value = k;
        tree->left = tree->right = NULL;
    }
    else if (k < tree->value)
    {
        if (tree->left != NULL) insert(tree->left, k);
        else
        {
            tree->left = new binTree<T>;
            tree->left->left = tree->left->right = NULL;
            tree->left->value = k;
        }

    }
    else if (k >= tree->value)
    {
        if (tree->right != NULL) insert(tree->right, k);
        else
        {
            tree->right = new binTree<T>;
            tree->right->right = tree->right->left = NULL;
            tree->right->value = k;
        }
    }
}


template <typename T>
void print(binTree<T>* r, int offset = 0)
{
    if (r == NULL) return;
    print(r->right, offset + 3);
    for (int i = 0; i < offset; i++) cout << " ";
    cout << r->value << endl;
    print(r->left, offset + 3);
}

template <typename T>
void isTreeEmpty(binTree<T>* root)
{
    if (root == NULL) cout << "������ ������." << endl;
    else cout << "������ �� ������." << endl;
}

template <typename T>
void deleteTree(binTree<T>* tree)
{
    if (tree != NULL)
    {
        deleteTree(tree->left);
        deleteTree(tree->right);
        delete[] tree;
        tree = NULL;
    }
}

template <typename T>
void findSimilar(binTree<T>* tree, int* count)
{
    if (tree != NULL)
    {
        *count = *count + 1;

        findSimilar(tree->left, count);
        findSimilar(tree->right, count);
    }

}

void printMenu()
{
    cout << "�������� ��������, �������������� � �������� �������:\n";
    cout << "1. �������� �������\n";
    cout << "2. ������� �������\n";
    cout << "3. ����� ������(���)\n";
    cout << "4. ����� ������(���)\n";
    cout << "5. ������� ������\n";
    cout << "6. ���������, ������ ��)\n";
    cout << "7. ������� ������\n";
    cout << "8. ����� 2 ���������� ��.\n";
    cout << "9. ����� �� ����\n";
}

int main()
{
    setlocale(LC_ALL, "rus");
    binTree<int>* tree = NULL;
    int* count = new int;
    vector<int> vec;

    system("cls");
    int task = 0;
    while (task != -1)
    {
        printMenu();
        while (!(cin >> task))
        {
            cout << "������� �����!\n";
            cin.clear();
            fflush(stdin);
        }
        switch (task)
        {
        case 1:
            int s;
            int n;
            cout << "������� ���-�� ���������, ������� ������ �������� � ������: " << endl;
            cin >> n;
            *count += n;
            for (int i = 0; i < n; ++i)
            {
                cin >> s;
                insert(tree, s);
                auto it = find(vec.begin(), vec.end(), s);
                if (it == vec.end()) vec.push_back(s);
            }
            break;
        case 2:
            cout << "������� �������: \n";
            int p;
            cin >> p;
            deleteElement(tree, p);
            break;
        case 3:
            cout << "����� ��������� ������ ������(���):" << endl;
            detourPKL(tree);
            break;
        case 4:
            cout << "����� ��������� ������ ������(���):" << endl;
            detourKLP(tree);
            break;

        case 5:
            if (tree == NULL) cout << "������ ������!\n";
            else {
                cout << "����� ������:\n";
                print(tree);
            }
            break;
        case 6:
            isTreeEmpty(tree);
            break;
        case 7:
            deleteTree(tree);
            cout << "������ ������� �������!\n";
            break;
        case 8:
            if (*count != vec.size()) cout << "���������� �������� ����!\n";
            else cout << "���������� ��������� ���!\n";
            break;
        case 9:
            task = -1;
            break;
        default:
            break;
        }
    }
    return 0;
}
