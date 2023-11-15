#include <stdio.h>
#include <stdlib.h> 
#include <pthread.h>
#include <semaphore.h>
#include <sys/types.h>
#include <unistd.h>

static int lock = 0;
static int a = 0;

static char buffer[100]; 

void *threadFunc1(void *vargp) {
    if (lock == 0) {
        lock = 1;

        for (int i = 0; i < 100; i++) {
            if (rand() % 2 == 0) {
                buffer[i] = 'a';
            }
        }
    } else {
        sleep(1);
    }

    lock = 0;

    return NULL;
}

void *threadFunc2(void *vargp) {
    if (lock == 0) {
        lock = 1;

        for (int i = 0; i < 100; i++) {
            if (rand() % 2 != 0) {
                buffer[i] = 'b';
            }
        }
    } else {
        sleep(1);
    }

    lock = 0;

    return NULL;
}

int main() {
    pthread_t thread_id1, thread_id2;

    pthread_create(&thread_id1, NULL, threadFunc1, NULL);

    sleep(1);

    pthread_create(&thread_id2, NULL, threadFunc2, NULL);

    pthread_join(thread_id1, NULL);
    pthread_join(thread_id2, NULL);

    for (int i = 0; i < 100; i++) {
        printf("%c", buffer[i]);
    }

    printf("\n");

    exit(0);
}