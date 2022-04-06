#include <iostream>
#include <cstring>
#include <string>
#include<algorithm>
void task1();
void task2();
void task3();
void task4();
char* gets(char* str);
char *delSubstr(char *s, char *ss) {
    char *t = nullptr;
    do {
        t= strstr (s, ss);
        if (t!=NULL) {
            char* t1= t+strlen (ss);
            strcpy (t, t1);
        }
        else
            break;
    } while (true);
    return s;
};


int main()
{
    /* int task = 0;
     std:: cout << "Nomer zadaniya:";
     while(task != -1){
         std::cin >> task;
         switch (task) {
             case 1:
                 task1();
                 break;
             default :
                 break;
         }
     }*/
    int task;
    std:: cout << "Nomer zadaniya:";
    std::cin >> task;
    if (task == 1)
    {
        task1();
    }
    else if (task == 2)
    {
        task2();
    }
    else if (task == 3)
    {
        task3();
    }
    else if (task == 4)
    {
        task4();
    }

}
void task1()
{
    char str1[100];
    std::cout << "Vvedite stroky";
    std::cin.ignore();
    gets(str1);
    for (int i = strlen(str1); i >= 0; i--)
    {
        std::cout << str1[i];
    }
    main();
};
void task2()
{
    char s[100], ss[100];
    std:: cout << "Vvedite S ";
    std:: cin.ignore();
    std:: cin.getline(s,80);
    std:: cout << "Vvedite podstroky ";
    std:: cin.getline (ss,80);
    std:: cout << delSubstr(s,ss) << std:: endl;
   main();
}
void task3()
{ char del[]="QqWwRrTtPpSsDdFfGgHhJjKkLlZzXxCcVvBbNnMm";
    char str[200]; // строка для ввода предложения
    char words[50][50];// массив для выделения слов
    while(true) {// вечный цикл считывания строк
        std::cin.ignore();
        gets(str); // считываем строку
        if(strlen(str)==0)
        {
           main();
        }; // если строка пустая, то выходим
        strcat(str," "); // добавляем к строке пробел, для упрощения обработки
        int numwords=0; // кол-во найденных слов
// цикл извлечения слов
        while(strlen(str)!=0) {
// удаляем все пробелы в начале строки
            while(str[0]==' ') strcpy(str,&str[1]);
            char *tmp=strchr(str,' '); // ищем позицию пробела в строке
            if(tmp!=NULL) { // если пробел найден, т.е. позиция не нулевая
                strcpy(words[numwords],str); // копируем строку в массив
                words[numwords][tmp-str]='\0'; // отсекаем слово по размеру
                strcpy(str,tmp); // копируем текст после найденного слова, т.е. удаляем найденное
                numwords++; // увеличиваем счетчик слов
            }
        }
       /* for( int i = 0;i < numwords;i++){

            for(int j = 0; j < strlen(str); ++j) {


                if (words[strlen(words[i]) - 1] == &del[j])//Если последня буква слова из строки гласная...
                {
                    printf("%s ", words);}
                }
            //...выводим это слово на экран
        }}*/
        // сортировка пузырьком

// выводим результат
        for(int i=0; i<numwords; i++) {
            int index;
            for(int j = 0; words[i][j] != '\0';j++) {
                index = j;
            }
            
            if((strchr(&words[i][index],'a') == NULL) && (strchr(&words[i][index],'e') == NULL) && (strchr(&words[i][index],'y') == NULL) && (strchr(&words[i][index],'u') == NULL) && (strchr(&words[i][index],'o') == NULL)&& (strchr(&words[i][index],'i') == NULL)){
                int back = index;
                while(words[i][back] != '\0' || back >= 0){
                    back--;
                }
                for(int j = 0; j <= index; j++){
                    std::cout << words[i][j];
                }
                std::cout << "\n";
            }

    }
    }
    main();
}
void task4()
{
    std:: string cryptstr, buf1, buf2, result;
    std:: cout << "Enter line:";
    std:: cin.ignore();
    getline(std:: cin, cryptstr);
    for (int i = cryptstr.length() - 1; i >= 0; i--)
    {
        if (i < cryptstr.length() - i - 1) {
            break;
            result += cryptstr[i];
        }

        if (i == cryptstr.length() - i - 1)
        {
            break;
        result += cryptstr[cryptstr.length() - i - 1];
        }


    }
    std:: cout << result << '\n';
main();

}