#!/bin/sh

set -xe

clang++ -Wall -Wextra -Wmissing-field-initializers -framework CoreVideo -framework IOKit -framework Cocoa -framework GLUT -framework OpenGL libraylib.a main.cc -I./raylib/src -I./ -o lab1 && ./lab1