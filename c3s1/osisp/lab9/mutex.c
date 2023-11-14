#include <stdio.h>
#include <stdlib.h> 
#include <pthread.h>
#include <semaphore.h>
#include <sys/types.h>
#include <unistd.h>

static pthread_mutex_t a_lock = PTHREAD_MUTEX_INITIALIZER;
static int a = 0;

void *threadFunc(void *vargp) {
    pthread_mutex_lock(&a_lock);

    a++;

    pthread_mutex_unlock(&a_lock);

    return NULL;
}

int main() {
    printf("BEGIN: a = %d\n", a);

    pthread_t thread_id1, thread_id2;

    pthread_create(&thread_id1, NULL, threadFunc, NULL);
    pthread_create(&thread_id2, NULL, threadFunc, NULL);

    pthread_join(thread_id1, NULL);
    pthread_join(thread_id2, NULL);

    printf("END: a = %d\n", a);

    exit(0);
}