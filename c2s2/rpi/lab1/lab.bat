@echo off
:start
echo 1 - down
echo 2 - right
echo 3 - left
set /p var=Option:
if "%var%" == "1" goto down
if "%var%" == "2" goto right
if "%var%" == "3" goto left


:down
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto down1

:down1
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto down2

:down2
echo 1 - back
echo 2 - start  
set /p var=Option:
if "%var%" == "1" goto down
if "%var%" == "2" goto start

:left
echo 1 - next   
echo 2 - exit  
set /p var=Option:
if "%var%" == "1" goto left1
if "%var%" == "2" goto exit

:left1
echo 1 - next   
set /p var=Option:
if "%var%" == "1" goto down


:right
echo 1 - exit
echo 2 - next    
set /p var=Option:
if "%var%" == "1" goto exit
if "%var%" == "2" goto right1

:right1
echo 1 - start
set /p var=Option:
if "%var%" == "1" goto start

:exit