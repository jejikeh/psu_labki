#include <Windows.h>
#include <string.h>
#include <iostream>
#include <cctype>
#include <locale>
#include <algorithm>

extern "C"
{
    __declspec(dllexport) const char* ToLower (const char *a)
    {
        std::string s = a;
        std::transform(s.begin(), s.end(), s.begin(), 
                   [](unsigned char c){ return std::tolower(c); }
                  );

        return _strdup(s.c_str());
    }

    __declspec(dllexport) const char* ToUpper (const char *a)
    {
        std::string s = a;
        std::transform(s.begin(), s.end(), s.begin(), 
                   [](unsigned char c){ return std::toupper(c); }
                  );

        return _strdup(s.c_str());
    }
}