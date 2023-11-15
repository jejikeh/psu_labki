#include <iostream>
#include <stdio.h>
#include <sys/ipc.h>
#include <sys/shm.h>

using namespace std;

int main()
{

    while (1) {

        int shmid = shmget(11111, 1024, 0666 | IPC_CREAT);
        char* str = (char*)shmat(shmid, (void*)0, 0);
            cout << "Write Data : ";
            cin.getline(str, 1024);

            cout << "Data written in memory: " << str << endl;

        shmdt(str);
    }

	return 0;
}
