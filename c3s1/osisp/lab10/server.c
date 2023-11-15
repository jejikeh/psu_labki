#include<stdlib.h>  
#include<stdio.h>  
#include<string.h>  
#include<unistd.h>  
#include<sys/types.h>  
#include<sys/ipc.h>  
#include<sys/msg.h>

#define MAX_TEXT 512
 
struct my_msg{  
         long int msg_type;  
         char some_text[MAX_TEXT];  
 };  

int main() {
    int run = 1;
    int msg_id, msg_id1;

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
        msgrcv(msg_id,(void *)&msg,BUFSIZ,msg_to_rec,0);

        printf("Data received: %s\n",msg.some_text);  

        // compare string.
        if (strncmp(msg.some_text, "kill_server", 11) == 0) {
            run = 0;
        }

        if (strncmp(msg.some_text, "hello from server", 17) == 0) {
            continue;
        }

        if (strncmp(msg.some_text, "hello", 5) == 0) {
            msg.msg_type = 1;
            strcpy(msg.some_text, "hello from server");
            if(msgsnd(msg_id1,(void *)&msg, MAX_TEXT,0)==-1) {
                printf("msgsnd failed");
            }
        } else {
            // send message
            msg.msg_type = 1;
            strcpy(msg.some_text, "server gets your message");
            if(msgsnd(msg_id1,(void *)&msg, MAX_TEXT,0)==-1) {
                printf("msgsnd failed");
            }
        }
    }
}