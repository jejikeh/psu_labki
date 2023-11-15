#include <iostream>
#include <stdio.h>
#include<string.h>  
#include <sys/ipc.h>
#include <sys/shm.h>
using namespace std;

int main()
{
	key_t key = ftok("shmfile", 65);

	int shmid = shmget(11111, 1024, 0666 | IPC_CREAT);
    while (1) {
	    char* str = (char*)shmat(shmid, (void*)0, 0); 
	    cout << "Data read from memory:" << str << std::endl;
	    shmdt(str);
    }

	shmctl(shmid, IPC_RMID, NULL);

	return 0;
}
