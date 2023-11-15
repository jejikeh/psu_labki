#include<stdlib.h>  
#include<stdio.h>  
#include<string.h>  
#include<unistd.h>  
#include<sys/types.h>  
#include <pthread.h>
#include<sys/ipc.h>  
#include<sys/msg.h>  

#define MAX_TEXT 512
 
struct my_msg{  
         long int msg_type;  
         char some_text[MAX_TEXT];  
 };  

struct my_msg msg_t;
int msg_id1;
long int msg_to_rec_t=0;


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

    msg_id1 = msgget((key_t)14535,0666|IPC_CREAT);
    if (msg_id == -1) {
        printf("msgget failed");
        exit(0);
    }

    while (run) {
        printf("enter some text:");

        // input data from keyboard
        fgets(buffer, 50, stdin);

        msg.msg_type = 1;
        strcpy(msg.some_text, buffer);

        // send data, return 0 if success
        if(msgsnd(msg_id,(void *)&msg, MAX_TEXT,0)==-1) {
            printf("msgsnd failed");
        }

        // receive data
        if(msgrcv(msg_id1,(void *)&msg, MAX_TEXT,0,msg_to_rec_t)==-1) {
            printf("msgrcv failed");
        }

        printf("Server: %s\n",msg.some_text);

        if (strncmp(buffer, "end", 3) == 0) {
            run = 0;
        }
    }
}