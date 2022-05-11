#include <iostream>
#include <cstring>



int *create_array(int sizeOfArray){ // Функция создания массива
    int *array = new int[sizeOfArray]; // Создание
    for(int i = 0;i <= sizeOfArray;i++){
        array[i] = rand()%50-25; // Заполнение элементов
    }
    return array;
}

void index_min(int * array, int sizeOfArray){
    int min = 100;
    int index = 0;
    for(int i = 0;i < sizeOfArray; i++){
        if(array[i] > array[i+1] && i+1 < sizeOfArray){ //  Текущий и следующий сравниваются, проверка на выход за края
            if(array[i+1] < min){ // Нахождение минимального
                min = array[i+1];
                index = i+1;
            }
        }
        std::cout << array[i] << " ";
    }
    std::cout << "\nIndex of minimal element : "<< index;
}

void sum_after_minus(int *array, int sizeOfArray){
    int i = 0;
    for(i = 0; i < sizeOfArray; i++){
        if(array[i] < 0){
            break; // До первого минимального
        }
    }
    int sum = 0;
    for(int k = i; k < sizeOfArray; k++){
        sum += abs(array[k]);
    }

    std::cout << "\nSum after minus : " << sum;
}



int task6_3() {
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

int main(){
    std::cout << "Input length of array : ";
    int sizeOfArray;
    std::cin >> sizeOfArray; // Размер массива
    int *array = create_array(sizeOfArray); // Создание массива
    index_min(array,sizeOfArray); // Нахождение минимального элемента
    sum_after_minus(array, sizeOfArray); // Сумма после первого отрицательного
    std::cin.ignore();
    std::cout << "\n";
    task6_3(); // 6 Лаболаторная 11 вариант 3 задание
}