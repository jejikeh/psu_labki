#include <iostream>
#include "course_work.h" // структура

COURSE_WORK *create(COURSE_WORK *course_work){ // функция создания
    std::cout << "Input name: ";
    std::cin >> course_work->name; // заполнение полей структуры
    std::cout << "Input topic: ";
    std::cin >> course_work->topic;
    std::cout << "Input author: ";
    std::cin >> course_work->author;
    std::cout << "Input pages: ";
    std::cin >> course_work->pages;

    return course_work; // возвращение элемента
}

void display(COURSE_WORK *course_work){
    std::cout << "Name : " << course_work->name << "\n" << "Topic : " << course_work->topic << "\n" << "Author : " << course_work->author << "\n" << "Pages : " << course_work->pages << "\n";

}