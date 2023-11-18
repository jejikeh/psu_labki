#include "critical_section.h"

int critical_section::execute() {
    InitializeCriticalSection(&critsec);

    HANDLE thread1 = CreateThread(nullptr, 0, critical_section::ThreadFunc1, this, 0, nullptr);
    HANDLE thread2 = CreateThread(nullptr, 0, critical_section::ThreadFunc2, this, 0, nullptr);

    WaitForSingleObject(thread1, INFINITE);
    WaitForSingleObject(thread2, INFINITE);

    CloseHandle(thread1);
    CloseHandle(thread2);
    DeleteCriticalSection(&critsec);

    return 0;
}