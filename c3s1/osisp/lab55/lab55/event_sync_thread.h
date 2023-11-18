#pragma once

#include <windows.h>
#include <iostream>

class event_sync_thread {
public:
    int execute();

    HANDLE event;

private:
    static DWORD WINAPI ThreadFunc1(LPVOID lpParam) {
        event_sync_thread* obj = reinterpret_cast<event_sync_thread*>(lpParam);
        for (int i = 0; i < 10; i++) {
            WaitForSingleObject(obj->event, INFINITE);
            std::cout << "Thread 1: " << i << std::endl;
            SetEvent(obj->event);
        }

        return 0;
    }

    static DWORD WINAPI ThreadFunc2(LPVOID lpParam) {
        event_sync_thread* obj = reinterpret_cast<event_sync_thread*>(lpParam);
        for (int i = 10; i < 20; i++) {
            WaitForSingleObject(obj->event, INFINITE);
            std::cout << "Thread 2: " << i << std::endl;
            SetEvent(obj->event);
        }

        return 0;
    }
};