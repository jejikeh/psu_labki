#include <iostream>
#include <windows.h>
#include "./event_sync_thread.h"
#include <conio.h>
#include "./semaphore_ex.h"
#include "critical_section.h"

int main() {
	while (true) {
		std::cout << "1: Event Sync\n";
		std::cout << "2: Semaphore\n";
		std::cout << "3: Critical Section\n";

		auto n = 0;
		std::cin >> n;

		switch (n)
		{
		case 1:
			event_sync_thread event_sync_thread;
			event_sync_thread.execute();
			break;
		case 2:
			semaphore_ex semaphore_ex;
			semaphore_ex.execute();
			break;
		case 3:
			critical_section critical_sec;
			critical_sec.execute();
			break;
		default:
			std::cout << "Invalid number! Please press any key...\n";
			const auto _ = _getch();
			break;
		}

		std::cout << "Please input to restart...\n";
		auto _ = _getch();
		std::cout << "============================\n";
	}
}