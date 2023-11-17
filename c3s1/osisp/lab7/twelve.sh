#!/bin/bash

echo "12. Запустите программу yes в фоновом режиме с подавлением потока
вывода. Используя утилиту nice, запустите программу yes с теми же параметрами и
с приоритетом, большим на 5. Сравните абсолютные и относительные приоритеты у
этих двух процессов."

yes > /dev/null &
pid1=$!

nice -n 5 yes > /dev/null &
pid2=$!

priority1=$(ps -o nice= -p $pid1)
priority2=$(ps -o nice= -p $pid2)

echo "PID процесса 1: $pid1, Абсолютный приоритет: $priority1"
echo "PID процесса 2: $pid2, Абсолютный приоритет: $priority2"

priority3=$(ps -o ni= -p $pid1)
priority4=$(ps -o ni= -p $pid2)

echo "PID процесса 1: $pid1, Относительный приоритет: $priority3"
echo "PID процесса 2: $pid2, Относительный приоритет: $priority4"
