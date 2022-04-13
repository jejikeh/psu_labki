#include <iostream>


// Создание строки
std::string create_string(int length, std::string character){
    std::string str = "";
    if(length > 0){
        for(int i = 0; i < length; i++){
            str.append(character);
        }
    }
    return str;
}

int task6_3() {
    std::string str;
    while(true) {
        std::cin >> str;
        if(str.length() == 0){ return 0; }
        for(int i = 0; i < str.length();i++){
            if(str[i] != ' '){
                std::cout << str[i];
            }
        }
        std::cout << "\n";
    }
    return 0;
}

int main(){
    std::string input_string;
    

    std::cout << "--- Task 1 ---\n";
    int length;
    std::cout << "Input a character : ";
    std::cin >> input_string;
    std::cout << "\nInput a string length : ";
    std::cin >> length;
    std::string _string = create_string(length,input_string);
    std::cout << _string;


    std::cout << "\n--- Task 2 ---\n";
    std::string s;
    std::string s1;
    std::string s2;
    std::cout << "Input a string : \n";
    std::cin >> s;
    std::cout << "Search a : \n";
    std::cin >> s1;
    std::cout << "Replace by : \n";
    std::cin >> s2;

    size_t found = s.find(s1);
    if (found != std::string::npos){
        //std::cout << "First occurrence is " << found << std::endl;
        s.replace(found,s1.length(),s2);
    }
    std::cout << "Your new string is : \n";
    std::cout << s;

    std::cout << "\n--- Task 3 ---\n";
    task6_3();

}