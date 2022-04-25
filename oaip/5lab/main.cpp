#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <cstring>
#include <bits/stdc++.h>


int main();


struct COURSE_WORK { // описание структуры
    std::string name;
    std::string topic;
    std::string author;
    std::string pages;
};


int length = -1;

COURSE_WORK *create(COURSE_WORK *course_work){ // функция создания
    std::cout << "Input name: ";
    std::cin >> course_work->name; // заполнение полей структуры
    std::cout << "\n Input topic: ";
    std::cin >> course_work->topic;
    std::cout << "\n Input author: ";
    std::cin >> course_work->author;
    std::cout << "\n Input pages: ";
    std::cin >> course_work->pages;

    return course_work; // возвращение элемента
}

int func1(struct COURSE_WORK *course_work ){ // вывод так же как и в func3
    std::cout << setiosflags(std::ios::left); // табличный вывод
    std::cout << "|" <<std::setw(10) <<"name"  << "|" << std::setw(10) << "topic"  << "|"<< std::setw(10)  << "author" << "|" << std::setw(10) << "pages" << "|\n";
    for(int i = 0; i < 5; i++){ // setw устанавливает количество элементов в данном выводе
        switch (i) {
            case 0:
                std::cout << "|" << std::setw(10) << course_work->name << "|";
                break;
            case 1:
                std::cout << std::setw(10) << course_work->topic << "|";
                break;
            case 2:
                std::cout << std::setw(10) << course_work->author << "|";
                break;
            case 3:
                std::cout << std::setw(10) << course_work->pages << "|";
                break;
            default:
                //std::cout << "\n Complete \n";
                break;
        }
    }
    std::cout << "\n";
    return 0;
}

// работа с файлами

void save_file(std::string name,COURSE_WORK *cw){
    std::ofstream fout(name, std::ios_base::app); // поток файла с конца
    //std::ofstream fout("data_types.txt", std::ios_base::out|std::ios_base::trunc); // поток файла с начала

    fout << cw->name << " " << cw->topic << " " << cw->author << " " << cw->pages << " "; // в открытый файл записываем значения полей структуры
    fout.close(); // закрываем поток
}

void clear(std::string name){
    std::ofstream fout;
    fout.open(name, std::ios_base::out|std::ios_base::trunc); // поток файла с начала
    if(!fout){
        std::cout << "Error";   
    }; // удаляем весь файл перед открытием
    //fout << "";
    fout.close();
}


void load(COURSE_WORK *course_work,std::string name,int number){
    std::fstream fout(name, std::ios::in); // поток файла с конца
    //std::ofstream fout("data_types.txt", std::ios_base::out|std::ios_base::trunc); // поток файла с начала
    if (!fout.is_open()) {
        std::cout << "error";
    }

    //d(fout,course_work);
    //fout.replace(fout.find(ch)),ch.length(),""); // так как fout >> работает только по одной строке, строку которую уже занесли удаляем
    for(int k = 0; k < number;k++){
        fout >> course_work[k].name >> course_work[k].topic >> course_work[k].author >> course_work[k].pages;
    }
    
    fout.close();
}

// 4 лаба


int func(struct COURSE_WORK *course_work ){ // вывод элемента
    for(int i = 0; i < 5; i++){
        switch (i) {
            case 0:
                std::cout << "\n name: ";
                std::cout << course_work->name;
                break;
            case 1:
                std::cout << "\n topic: ";
                std::cout << course_work->topic;
                break;
            case 2:
                std::cout << "\n author: ";
                std::cout << course_work->author;
                break;
            case 3:
                std::cout << "\n Pages: ";
                std::cout << course_work->pages << "\n";
                break;
            default:
                break;
        }
    }
    return 0;
}

int main() {

    COURSE_WORK* course_work = new COURSE_WORK[100]; // создание массива структур и выделение памяти под нее
    int i = 0;

    while( i != -1 ){ // выбор задания
        std::cout << "1 - Create new object \n2 - Table output \n3 - String output \n4 - Save file ( 1, 3, 4)\n5 - Delete file ( 2 )\n( -1 ) - Exit \n";
        std::cin >> i;
        if( i == 1){
            length++; // увелечение элемента на один
            course_work[length] = *create(&course_work[length]); // если пользователь выбрал добавить в массив, то в массиве по индексу длинны массива добавляется элемент
            std::cout << length;
        } else if (i == 2){
            std::cout << "Choose a element of array \n";
            int index;
            std::cin >> index;

            if(index > length || index < 0){ // если введенное число больше количества элементов
                std::cout << "Incorrect number \n";
            } else {
                func(&course_work[index]);
            }
        }else if (i == 3){
            std::cout << "Choose a element of array \n";
            int index;
            std::cin >> index; // выбор элемента какого выводить

            if(index > length || index < 0){ // если введенное число больше количества элементов
                std::cout << "Incorrect number \n";
            } else {
                func1(&course_work[index]);
            }
        }else if(i == 4){
            std::string name;
            std::cout << "\nInput a name of file : ";
            std::cin >> name;
            clear(name);
            for(int index = 0; index <= length;index++){
                save_file(name,&course_work[index]); // заново записываем в файл весь массив структур
            }
            
        }
        else if(i == 5){
            char name[] = {}; // массив символов т.к remove принимает значение только в char * []
            std::cout << "\nInput a name of file : ";
            std::cin >> name;
            remove(name); // удаление файла по имени 
        }
        else if(i == 6){
            std::string name;
            std::cout << "\nInput a name of file : ";
            std::cin >> name;
            std::fstream fout(name, std::ios::in); // поток файла с конца
            //std::ofstream fout("data_types.txt", std::ios_base::out|std::ios_base::trunc); // поток файла с начала
            if (!fout.is_open()) {
                std::cout << "error";
            }
            
            length = std::count(std::istream_iterator<char>(fout >> std::noskipws), {}, ' ');
            fout.close();
            std::cout << length/5;
            
            load(course_work,name,length/4);
            
        }else if (i == -1){
            break;
        }
    }
    delete[](course_work); // если пользователь выбрал выход из задания то происходит освобождение памяти
}