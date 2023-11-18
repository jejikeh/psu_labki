#pragma once

#include <windows.h>
#include <iostream>

class critical_section {
public:
    int execute();

    CRITICAL_SECTION critsec;

private:
    static DWORD WINAPI ThreadFunc1(LPVOID lpParam) {
        critical_section* obj = reinterpret_cast<critical_section*>(lpParam);
        EnterCriticalSection(&obj->critsec);

        for (int i = 0; i < 10; i++) {
            // Or enter critical here ->
            std::cout << "Thread 1: " << i << std::endl;
            // And leave here <-
        }

        LeaveCriticalSection(&obj->critsec);

        return 0;
    }

    static DWORD WINAPI ThreadFunc2(LPVOID lpParam) {
        critical_section* obj = reinterpret_cast<critical_section*>(lpParam);
        EnterCriticalSection(&obj->critsec);

        for (int i = 10; i < 20; i++) {
            std::cout << "Thread 2: " << i << std::endl;
        }

        LeaveCriticalSection(&obj->critsec);

        return 0;
    }
};