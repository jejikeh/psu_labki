#include <iostream>
#include "structure.cpp"


void menu(void){
    int _task = 0;
    COURSE_WORK* course_work = new COURSE_WORK[10];
    while(_task != -1){
        std::cout << "1 - Add element\n2 - Display element\n CHOOSE TASK : ";
        std::cin >> _task;
        switch(_task){
            case 1 : {
                length++;
                course_work[length] = *create(&course_work[length]);
                break;
            case : 2 {

                }
            }default : {
                std::cout << "D";
            }
        }
    }
}