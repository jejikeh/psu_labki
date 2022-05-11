#include <iostream>
#include <cstring>
#include "../structure/structure.h"
#include "../structure/course_work.h"
#include "../files/files.h"

int length = -1;

void menu(void){
    int _task = 0;
    COURSE_WORK* course_work = new COURSE_WORK[10];
    while(_task != -1){
        std::cout << "1 - Add element\n2 - Display element\n3 - Save file\nCHOOSE TASK : ";
        std::cin >> _task;
        switch(_task){
            case 1 : 
                length++;
                course_work[length] = *create(&course_work[length]);
                std::cout << course_work[length].author;
                break;
            case 2 :
                for(int i = 0;i <= length;i++){
                    std::cout << "\n\nDisplay " << i << " element....\n";
                    display(&course_work[i]);
                }
                break;
            case 3 :
            {
                std::string fileName;
                std::string str;
                std::cout << "\nEnter file name : ";
                std::cin >> fileName;
                clear_file(fileName);
                for(int i = 0;i <= length;i++){
                    save_file(fileName,"---");
                    save_file(fileName,std::to_string(i));
                    save_file(fileName," element");
                    save_file(fileName,"---");
                    save_file(fileName,"\nNAME : ");
                    save_file(fileName,course_work[i].name);
                    save_file(fileName,"\nTOPIC : ");
                    save_file(fileName,course_work[i].topic);
                    save_file(fileName,"\nAUTHOR : ");
                    save_file(fileName,course_work[i].author);
                    save_file(fileName,"\nPAGES : ");
                    save_file(fileName,course_work[i].pages);
                    save_file(fileName,"\n");
                }
                break;
            }
            default :
                std::cout << "\nWrong task.";
                break;
        }
    }
}