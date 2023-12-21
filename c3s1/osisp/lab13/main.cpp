#define _WIN32_WINNT 0x0500 //RIGHT
#include "Windows.h"
#pragma comment( lib, "user32.lib" )

#include <stdio.h>
#include <WinUser.h>

HHOOK hKeyboardHook;

void pressKeyB(char key)
{
    HKL kbl = GetKeyboardLayout(0);
    INPUT ip;
    ip.type = INPUT_KEYBOARD;
    ip.ki.time = 0;
    ip.ki.dwFlags = KEYEVENTF_UNICODE;

    if ((int)key<65 || (int)key>90) //for lowercase
    {

        ip.ki.wScan = 0;
        ip.ki.wVk = VkKeyScanEx( key, kbl );
    }
    else //for uppercase
    {
        ip.ki.wScan = key;
        ip.ki.wVk = 0;

    }
    ip.ki.dwExtraInfo = 0;
    if (GetKeyState(ip.ki.wVk) & 0x0001) { 
        SendInput(1, &ip, sizeof(INPUT));
    }
}

__declspec(dllexport) LRESULT CALLBACK KeyboardEvent (int nCode, WPARAM wParam, LPARAM lParam)
{
    DWORD SHIFT_key=0;
    DWORD CTRL_key=0;
    DWORD ALT_key=0;

    if  ((nCode == HC_ACTION) &&   ((wParam == WM_SYSKEYDOWN) ||  (wParam == WM_KEYDOWN)))      
    {
        KBDLLHOOKSTRUCT hooked_key =    *((KBDLLHOOKSTRUCT*)lParam);
        DWORD dwMsg = 1;
        dwMsg += hooked_key.scanCode << 16;
        dwMsg += hooked_key.flags << 24;
        char lpszKeyName[1024] = {0};
        //lpszKeyName[0] = '[';

        int i = GetKeyNameText(dwMsg,   (lpszKeyName+1),0xFF) + 1;
        //lpszKeyName[i] = ']';

        int key = hooked_key.vkCode;

        SHIFT_key = GetAsyncKeyState(VK_SHIFT);
        CTRL_key = GetAsyncKeyState(VK_CONTROL);
        ALT_key = GetAsyncKeyState(VK_MENU);

        if (key >= 'A' && key <= 'Z')   
        {

            if  (GetAsyncKeyState(VK_SHIFT)>= 0) key +=32;

            //printf("key = %c\n", key);
            printf("ha ha, I intercepted your [%c] and changed it to [%c]\n", key, toupper(key));

                pressKeyB(toupper(key));

    
            SHIFT_key = 0;
            CTRL_key = 0;
            ALT_key = 0;

        }

        //printf("lpszKeyName = %s\n",  lpszKeyName );
    //  printf("%s",  lpszKeyName );
    }
    return CallNextHookEx(hKeyboardHook,    nCode,wParam,lParam);
}

void MessageLoop()
{
    MSG message;
    while (GetMessage(&message,NULL,0,0)) 
    {
        TranslateMessage( &message );
        DispatchMessage( &message );
    }
}

DWORD WINAPI my_HotKey(LPVOID lpParm)
{
    HINSTANCE hInstance = GetModuleHandle(NULL);
    if (!hInstance) hInstance = LoadLibrary((LPCSTR) lpParm); 
    if (!hInstance) return 1;

    hKeyboardHook = SetWindowsHookEx (  WH_KEYBOARD_LL, (HOOKPROC) KeyboardEvent,   hInstance,  NULL    );
    MessageLoop();
    UnhookWindowsHookEx(hKeyboardHook);
    return 0;
}

int main(int argc, char** argv)
{
    HANDLE hThread;
    DWORD dwThread;

    hThread = CreateThread(NULL,NULL,(LPTHREAD_START_ROUTINE)   my_HotKey, (LPVOID) argv[0], NULL, &dwThread);

    //ShowWindow(FindWindowA("ConsoleWindowClass", NULL), false);

    if (hThread) return WaitForSingleObject(hThread,INFINITE);
    else return 1;

}