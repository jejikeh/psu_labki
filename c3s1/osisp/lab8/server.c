#include<stdlib.h>  
 #include<stdio.h>  
 #include<string.h>  
 #include<unistd.h>  
 #include<sys/types.h>  
 #include<sys/ipc.h>  
 #include<sys/msg.h>  
#include <semaphore.h>

static int semaphore_example(void);

#define MAX_TEXT 512
 
struct my_msg{  
         long int msg_type;  
         char some_text[MAX_TEXT];  
 };  

int main() {
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

        printf("Data received: %s\n",msg.some_text);  

        // compare string.
        if (strncmp(msg.some_text, "kill_server", 11) == 0) {
            run = 0;
        }

        if (strncmp(msg.some_text, "semaphore", 9) == 0) {
            semaphore_example();
        }
    }
}

#define SEM_NAME "/semaphoreexample"
#define SEM_PERMS (S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP)
#define INITIAL_VALUE 1

#define CHILD_PROGRAM "./child.out"

int semaphore_example() {

    /* We initialize the semaphore counter to 1 (INITIAL_VALUE) */
    sem_t *semaphore = sem_open(SEM_NAME, O_CREAT | O_EXCL, SEM_PERMS, INITIAL_VALUE);

    if (semaphore == SEM_FAILED) {
        perror("sem_open(3) error");
        exit(-1);
    }

    /* Close the semaphore as we won't be using it in the parent process */
    if (sem_close(semaphore) < 0) {
        perror("sem_close(3) failed");
        /* We ignore possible sem_unlink(3) errors here */
        sem_unlink(SEM_NAME);
        exit(-1);
    }

    pid_t pids[2];
    size_t i;

    for (i = 0; i < sizeof(pids)/sizeof(pids[0]); i++) {
        if ((pids[i] = fork()) < 0) {
            perror("fork(2) failed");
            exit(-1);
        }

        if (pids[i] == 0) {
            if (execl(CHILD_PROGRAM, CHILD_PROGRAM, NULL) < 0) {
                perror("execl(2) failed");
                exit(-1);
            }
        }
    }

    for (i = 0; i < sizeof(pids)/sizeof(pids[0]); i++)
        if (waitpid(pids[i], NULL, 0) < 0)
            perror("waitpid(2) failed");

    if (sem_unlink(SEM_NAME) < 0)
        perror("sem_unlink(3) failed");

    return 0;
}