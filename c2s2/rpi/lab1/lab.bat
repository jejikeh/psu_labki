@echo off
:start
echo 1 - upleft
echo 2 - upright
echo 3 - downleft
echo 4 - downright
set /p var=Option:
if "%var%" == "1" goto upleft
if "%var%" == "2" goto upright
if "%var%" == "3" goto downleft
if "%var%" == "4" goto downright


:upleft
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto start


:upright
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto start


:downleft
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto down


:downright
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto down


:down
echo 1 - start
set /p var=Option:
if "%var%" == "1" goto start
:exit