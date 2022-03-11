#include <iostream>
#include <cstring>

int main() {
    char str[200];
    char words[50][50];
    while(true) {
        gets(str);
        if(strlen(str)==0) return 0;
        strcat(str," ");
        int numwords=0;
        while(strlen(str)!=0) {
            while(str[0]==' ') strcpy(str,&str[1]);
            char *tmp=strchr(str,' ');
            if(tmp!=nullptr) {
                strcpy(words[numwords],str);
                words[numwords][tmp-str]='\0';
                strcpy(str,tmp);
                numwords++;
            }
        }
        for(int k=0; k<numwords; k++)
            printf("%20s\n",words[k]);
    }
    return 0;
}