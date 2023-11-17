#!/bin/bash

echo "11. Запустите три процесса команды yes. Завершите работу процессов
одновременно, используя команду killall."

yes > /dev/null & yes > /dev/null & yes > /dev/null &;
killall yes