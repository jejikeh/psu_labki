#include <windows.h>
#include <iostream>
#include <fstream>
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <string>
#include <ctype.h>
#include <cstdio>
#include <cstring>
#include <windows.h>
using namespace std;
bool isPunctuator(char ch)
{
    if (ch == ' ' || ch == '+' || ch == '-' || ch == '*' ||
        ch == '/' || ch == ',' || ch == '>' ||
        ch == '<' || ch == '(' || ch == ')' ||
        ch == '[' || ch == ']' || ch == '{' || ch == '}' ||
        ch == '&' || ch == '|')
    {
        return true;
    }
    return false;
}

bool validIdentifier(char* str)
{
    if (str[0] == '0' || str[0] == '1' || str[0] == '2' ||
        str[0] == '3' || str[0] == '4' || str[0] == '5' ||
        str[0] == '6' || str[0] == '7' || str[0] == '8' ||
        str[0] == '9' || isPunctuator(str[0]) == true)
    {
        return false;
    }
    int i, len = strlen(str);
    if (len == 1)
    {
        return true;
    }
    else
    {
        for (i = 1; i < len; i++)
        {
            if (isPunctuator(str[i]) == true)
            {
                return false;
            }
        }
    }
    return true;
}
bool isRavno(char str)
{
    if (str == '=') return true;
    else return false;
}
bool isZnak(char str)
{
    if (str == ';') return true;
    else return false;
}
bool isDelimetr(char str)
{
    if (str == '(' || str == ')' || str == '{' || str == '}') return true;
    else return false;
}

bool isOperator(char ch)
{
    if (ch == '+' || ch == '-' || ch == '*' ||
        ch == '/' || ch == '>' || ch == '<' || ch == '|' || ch == '&')
    {
        return true;
    }
    return false;
}

bool isKeyword(char* str)
{
    if (!strcmp(str, "if") || !strcmp(str, "else") ||
        !strcmp(str, "while") || !strcmp(str, "do") ||
        !strcmp(str, "break") || !strcmp(str, "continue")
        || !strcmp(str, "int") || !strcmp(str, "double")
        || !strcmp(str, "float") || !strcmp(str, "return")
        || !strcmp(str, "char") || !strcmp(str, "case")
        || !strcmp(str, "long") || !strcmp(str, "short")
        || !strcmp(str, "typedef") || !strcmp(str, "switch")
        || !strcmp(str, "unsigned") || !strcmp(str, "void")
        || !strcmp(str, "static") || !strcmp(str, "struct")
        || !strcmp(str, "sizeof") || !strcmp(str, "long")
        || !strcmp(str, "volatile") || !strcmp(str, "typedef")
        || !strcmp(str, "enum") || !strcmp(str, "const")
        || !strcmp(str, "union") || !strcmp(str, "extern")
        || !strcmp(str, "bool") || !strcmp(str, "cout")
        || !strcmp(str, "or") || !strcmp(str, "and")
        || !strcmp(str, "then")) return true;
    else return false;
}
bool isIf(char* str)
{
    if (!strcmp(str, "if")) return true;
    else return false;
}
bool isThen(char* str)
{
    if (!strcmp(str, "then")) return true;
    else return false;
}
bool isAnd(char* str)
{
    if (!strcmp(str, "and")) return true;
    else return false;
}
bool isOr(char* str)
{
    if (!strcmp(str, "or")) return true;
    else return false;
}
bool isEnd(char* str)
{
    if (!strcmp(str, ";")) return true;
    else return false;
}
bool isRav(char* str)
{
    if (!strcmp(str, ":=")) return true;
    else return false;
}

bool isNumber(char* str)
{
    int i, len = strlen(str), numOfDecimal = 0;
    if (len == 0)
    {
        return false;
    }
    for (i = 0; i < len; i++)
    {
        if (numOfDecimal > 1 && str[i] == '.')
        {
            return false;
        }
        else if (numOfDecimal <= 1)
        {
            numOfDecimal++;
        }
        if (str[i] != '0' && str[i] != '1' && str[i] != '2'
            && str[i] != '3' && str[i] != '4' && str[i] != '5'
            && str[i] != '6' && str[i] != '7' && str[i] != '8'
            && str[i] != '9' || (str[i] == '-' && i > 0))
        {
            return false;
        }
    }
    return true;
}

char* subString(char* realStr, int l, int r)
{
    int i;

    char* str = (char*)malloc(sizeof(char) * (r - l + 2));

    for (i = l; i <= r; i++)
    {
        str[i - l] = realStr[i];
        str[r - l + 1] = '\0';
    }
    return str;
}
string parse(char* str)
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    bool temp = false;
    string operators = "";
    string znakov = "";
    string dels = "";
    string keys = "";
    string numbs = "";
    string idents = "";
    string hexs = "";
    string errors = "";
    string znaks = "";
    string strd = "";
    string temp2 = "";
    string temp3 = "";
    string temp5[10];
    int i = 0;
    int left = 0, right = 0;
    int len = strlen(str);
    while (right <= len && left <= right) {
        if (isPunctuator(str[right]) == false)
        {
            right++;
        }

        if (isPunctuator(str[right]) == true && left == right)
        {
            if (isZnak(str[right]) == true)
            {
                znaks = znaks + str[right] + " ";
            }
            if (isOperator(str[right]) == true)
            {
                operators = operators + str[right] + " ";
            }
            if (isRavno(str[right]) == true)
            {
                znakov = znakov + str[right] + " ";
            }
            if (isDelimetr(str[right]) == true)
            {
                dels = dels + str[right] + " ";
            }
            right++;
            left = right;
        }
        else if (isPunctuator(str[right]) == true && left != right
            || (right == len && left != right))
        {
            char* sub = subString(str, left, right - 1);
            if (temp) {
                if (isEnd(sub) == true) {
                    strd = strd + '\n' + temp2;
                    temp = false;
                }
                if (isIf(sub) != true && isThen(sub) != true) {
                    if (isAnd(sub) == true) {
                        temp2 += " and";
                        temp3 += "    ";
                        temp5[i++] = "and [a,a]";
                    }
                    else if (isOr(sub) == true) {
                        temp2 += " or";
                        temp3 += "   ";
                        temp5[i++] = "or [a,a]";
                    }
                    else if (isRav(sub) == true) {
                        temp2 += " :=";
                        temp3 += "   ";
                        temp5[i++] = ":= [a,a]";
                    }
                    else {
                        temp3 = temp3 + " a";
                        temp2 = temp2 + " " + "E";
                    }
                }
            }
            if (isIf(sub) == true) {
                strd = "if E then E";
                temp5[i++] = "If [E,E]";
                temp = true;
            }
            if (isKeyword(sub) == true)
            {
                keys = keys + sub + " ";
            }
            else if (isNumber(sub) == true)
            {
                numbs = numbs + sub + " ";
            }
            else if (validIdentifier(sub) == true
                && isPunctuator(str[right - 1]) == false)
            {
                idents = idents + sub + " ";
            }
            else if (validIdentifier(sub) == false
                && isPunctuator(str[right - 1]) == false)
            {
                errors = errors + sub + " ";
            }
            left = right;

        }
    }
    temp3.pop_back();
    strd = strd + '\n' + temp3;
    for (int j = 0; j<10; j++) {
    if(temp5[j]!="") strd = strd + '\n' + temp5[j];
    }
    return strd;
}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int a, b;
    char str[100];
    string final = "";
    gets_s(str);
    strcat(str, " ;");
    cout << "    E" << endl;
    cout << "   E ;" << endl;
    final += parse(str);
    cout << final;
    return 0;
}