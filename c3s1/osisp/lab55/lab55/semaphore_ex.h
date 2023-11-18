#pragma once

#include <windows.h>
#include <iostream>

class semaphore_ex {
public:
    int execute();

    HANDLE semaphore;

private:
    static DWORD WINAPI ThreadFunc1(LPVOID lpParam) {
        semaphore_ex* obj = reinterpret_cast<semaphore_ex*>(lpParam);
        for (int i = 0; i < 10; ++i) {
            WaitForSingleObject(obj->semaphore, INFINITE);
            std::cout << "Thread 1: " << i << std::endl;
            ReleaseSemaphore(obj->semaphore, 1, nullptr);
        }

        return 0;
    }

    static DWORD WINAPI ThreadFunc2(LPVOID lpParam) {
        semaphore_ex* obj = reinterpret_cast<semaphore_ex*>(lpParam);
        for (int i = 10; i < 20; ++i) {
            WaitForSingleObject(obj->semaphore, INFINITE);
            std::cout << "Thread 2: " << i << std::endl;
            ReleaseSemaphore(obj->semaphore, 1, nullptr);
        }

        return 0;
    }
};