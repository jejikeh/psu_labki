#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>
#include <io.h>


void controlledProcess(HANDLE controlledProcess, HANDLE logFile) {
    // Ваш код для управляемого процесса
    // ...

    // Закрытие дескрипторов
    CloseHandle(controlledProcess);
    CloseHandle(logFile);
}

int main() {
    // Создание файла протокола
    HANDLE logFileHandle = CreateFileA(
        "log_file.txt",
        GENERIC_READ | GENERIC_WRITE,
        0,
        NULL,
        OPEN_ALWAYS,
        FILE_ATTRIBUTE_NORMAL,
        NULL
    );

    if (logFileHandle == INVALID_HANDLE_VALUE) {
        std::cerr << "Error opening the file: " << GetLastError() << std::endl;
        return 1;
    }

    // Создание управляемого процесса (например, notepad)
    STARTUPINFOA startupInfo;
    PROCESS_INFORMATION controlledProcessInfo;

    ZeroMemory(&startupInfo, sizeof(startupInfo));
    startupInfo.cb = sizeof(startupInfo);

    if (!CreateProcessA(
            nullptr,                  // Имя исполняемого файла
            "notepad.exe",            // Параметры командной строки
            nullptr,                  // Атрибуты процесса
            nullptr,                  // Атрибуты потока
            FALSE,                    // Наследование описателя
            0,                        // Флаги создания
            nullptr,                  // Среда выполнения
            nullptr,                  // Текущий каталог
            &startupInfo,
            &controlledProcessInfo)
    ) {
        std::cerr << "Error creating controlled process" << std::endl;
        return 1;
    }

    // Создание управляющего процесса
    SECURITY_ATTRIBUTES securityAttributes;
    securityAttributes.nLength = sizeof(SECURITY_ATTRIBUTES);
    securityAttributes.bInheritHandle = TRUE;
    securityAttributes.lpSecurityDescriptor = nullptr;

    HANDLE controlledProcess = controlledProcessInfo.hProcess;

    // Создание трубы для передачи дескрипторов
    HANDLE pipeRead, pipeWrite;
    if (!CreatePipe(&pipeRead, &pipeWrite, &securityAttributes, 0)) {
        std::cerr << "Error creating pipe" << std::endl;
        return 1;
    }

    // Передача дескрипторов управляемого процесса и файла протокола в управляющий процесс
    HANDLE handlesToInherit[] = { controlledProcess, logFileHandle };
    if (!SetHandleInformation(pipeWrite, HANDLE_FLAG_INHERIT, HANDLE_FLAG_INHERIT)) {
        std::cerr << "Error setting handle information" << std::endl;
        return 1;
    }

    DWORD bytesWritten;
    WriteFile(pipeWrite, handlesToInherit, sizeof(handlesToInherit), &bytesWritten, nullptr);

    // Создание управляющего процесса
    STARTUPINFOA startupInfoControlled;
    PROCESS_INFORMATION controlledProcessInfoControlled;

    ZeroMemory(&startupInfoControlled, sizeof(startupInfoControlled));
    startupInfoControlled.cb = sizeof(startupInfoControlled);

    if (!CreateProcessA(
            nullptr,
            "C:/Users/jejikeh/not/lab11/cont.exe", // Укажите путь к исполняемому файлу управляющего процесса
            nullptr,
            nullptr,
            TRUE,
            0,
            nullptr,
            nullptr,
            &startupInfoControlled,
            &controlledProcessInfoControlled)
    ) {
        std::cerr << "Error creating controlling process:" << GetLastError() << std::endl;
        return 1;
    }

    // Закрытие ненужных дескрипторов
    CloseHandle(pipeRead);
    CloseHandle(pipeWrite);

    // Ожидание завершения управляющего процесса
    WaitForSingleObject(controlledProcessInfoControlled.hProcess, INFINITE);

    // Закрытие дескрипторов управляемого и управляющего процессов
    CloseHandle(controlledProcessInfo.hProcess);
    CloseHandle(controlledProcessInfo.hThread);
    CloseHandle(controlledProcessInfoControlled.hProcess);
    CloseHandle(controlledProcessInfoControlled.hThread);

    return 0;
}
