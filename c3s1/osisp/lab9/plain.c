#include <stdio.h>
#include <stdlib.h> 
#include <pthread.h>
#include <semaphore.h>
#include <sys/types.h>
#include <unistd.h>

int main() {
    FILE *fp = fopen("file.txt", "a");

    if (fp == NULL) {
        perror("Error opening file");
        exit(1);
    }

    fprintf(fp, "Hello, World! From thread 1");
    fclose(fp);

    fp = fopen("file.txt", "a");

    if (fp == NULL) {
        perror("Error opening file");
        exit(1);
    }

    fprintf(fp, "Hello, World! From thread 2");
    fclose(fp);

    exit(0);
}