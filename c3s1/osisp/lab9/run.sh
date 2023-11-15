#!/bin/bash

echo "run mutex ========"
time ./mutex.out

echo "run vars ========="
time ./vars.out

echo "run sem ========"
time ./sem.out

echo "run plain ========="
time ./plain.out