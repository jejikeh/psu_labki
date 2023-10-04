#include <fcntl.h>
#include <unistd.h>
#include <semaphore.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <sys/wait.h>
#include<stdlib.h>  
 #include<stdio.h>  
 #include<string.h>  
 #include<sys/ipc.h>  
 #include<sys/msg.h>  

#define SEM_NAME "/semaphoreexample"
#define ITERS 10

#define MAX_TEXT 512
 
struct my_msg{  
         long int msg_type;  
         char some_text[MAX_TEXT];  
 };  

int main(void) {
    sem_t *semaphore = sem_open(SEM_NAME, O_RDWR);
    if (semaphore == SEM_FAILED) {
        perror("sem_open(3) failed");
        exit(-1);
    }

    int i;
    for (i = 0; i < ITERS; i++) {
        if (sem_wait(semaphore) < 0) {
            perror("sem_wait(3) failed on child");
            continue;
        }

        printf("PID %ld acquired semaphore\n", (long) getpid());

        if (sem_post(semaphore) < 0) {
            perror("sem_post(3) error on child");
        }

        int run = 1;
        int msg_id;

        long int msg_to_rec=0;  

        struct my_msg msg;

        char buffer[50];

        msg_id = msgget((key_t)14534,0666|IPC_CREAT);
        if (msg_id == -1) {
            printf("msgget failed");
            exit(0);
        }

        while (run) {
            msgrcv(msg_id,(void *)&msg,BUFSIZ,msg_to_rec,0);

            printf("Data child %ld received: %s\n", (long) getpid() ,msg.some_text);  

            // compare string.
            if (strncmp(msg.some_text, "kill_server", 11) == 0) {
                run = 0;
            }
        }

        sleep(1);
    }

    if (sem_close(semaphore) < 0)
        perror("sem_close(3) failed");

    return 0;
}