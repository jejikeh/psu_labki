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
    int msg_id;

    struct my_msg msg;

    char buffer[50];

    msg_id = msgget((key_t)14534,0666|IPC_CREAT);
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

        if (strncmp(buffer, "end", 3) == 0) {
            run = 0;
        }
    }
}