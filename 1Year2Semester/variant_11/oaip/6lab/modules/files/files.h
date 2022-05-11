#ifndef FILES_H
#define FILES_H

struct COURSE_WORK;

void save_file(std::string fileName, std::string str);
void clear_file(std::string name);
void load_file(std::string name,COURSE_WORK *course_work);

#endif