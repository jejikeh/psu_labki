#!/bin/bash

nohup sleep 60 > /dev/null &
pid_nohup=$!
sleep 60 > /dev/null &
pid_regular=$!

kill -SIGHUP $pid_nohup

kill -SIGHUP $pid_regular
