#include <stdio.h>
#include <stdlib.h> 
#include <pthread.h>
#include <semaphore.h>
#include <sys/types.h>
#include <unistd.h>

sem_t semaphore;

void *threadFunc(void *vargp) {
    sem_wait(&semaphore);

    pid_t t_id = getpid();

    FILE *fp = fopen("file.txt", "a");

    if (fp == NULL) {
        perror("Error opening file");
        exit(1);
    }

    fprintf(fp, "Hello, World! From thread %d\n", t_id);
    fclose(fp);

    sem_post(&semaphore);

    return NULL;
}

int main() {
    sem_init(&semaphore, 0, 1);

    pthread_t thread_id1, thread_id2;

    pthread_create(&thread_id1, NULL, threadFunc, NULL);
    pthread_create(&thread_id2, NULL, threadFunc, NULL);

    pthread_join(thread_id1, NULL);
    pthread_join(thread_id2, NULL);

    sem_destroy(&semaphore);

    exit(0);
}