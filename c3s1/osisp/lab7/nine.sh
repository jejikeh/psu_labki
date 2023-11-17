#!/bin/bash

sleep 60 > /dev/null &
pid1=$!
sleep 60 > /dev/null &
pid2=$!

# Убить процесс по PID
kill $pid1

# Убить процесс по идентификатору задания
kill %1