#include <iostream>
#include <fstream>
#include "../structure/course_work.h"

void clear_file(std::string name){
    std::ofstream fout;
    fout.open(name,std::ios_base::out|std::ios_base::trunc);
    if(!fout){
        std::cout << "Error while clear file...";
    }
    fout << "";
    fout.close();
}

void save_file(std::string fileName, std::string str){
    std::ofstream fout(fileName, std::ios_base::app);
    fout << str;
    fout.close();
}