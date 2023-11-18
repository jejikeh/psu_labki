#include "semaphore_ex.h"
#include <cassert>
#include <cstdint>
int semaphore_ex::execute()
{
    semaphore = CreateSemaphore(nullptr, 1, 1, nullptr);

    HANDLE thread1 = CreateThread(nullptr, 0, semaphore_ex::ThreadFunc1, this, 0, nullptr);
    HANDLE thread2 = CreateThread(nullptr, 0, semaphore_ex::ThreadFunc2, this, 0, nullptr);

    WaitForSingleObject(thread1, INFINITE);
    WaitForSingleObject(thread2, INFINITE);

    CloseHandle(thread1);
    CloseHandle(thread2);
    CloseHandle(semaphore);

    return 0;
}