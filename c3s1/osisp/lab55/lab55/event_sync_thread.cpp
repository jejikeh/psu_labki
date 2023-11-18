#include "event_sync_thread.h"
#include <iostream>
#include <windows.h>


int event_sync_thread::execute()
{
    event = CreateEvent(nullptr, FALSE, FALSE, nullptr);

    HANDLE thread1 = CreateThread(nullptr, 0, ThreadFunc1, this, 0, nullptr);
    HANDLE thread2 = CreateThread(nullptr, 0, ThreadFunc2, this, 0, nullptr);

    SetEvent(event);

    WaitForSingleObject(thread1, INFINITE);
    WaitForSingleObject(thread2, INFINITE);

    CloseHandle(thread1);
    CloseHandle(thread2);
    CloseHandle(event);

    return 0;
}