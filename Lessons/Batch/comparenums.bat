@echo off
setlocal
set n1=30000000000000
set n2=40000000000
call :padNum n1
call :padNum n2
if "%n1%" gtr "%n2%" echo %n1% is greater than %n2%
if "%n1%" lss "%n2%" echo %n1% is less than %n2%
if "%n1%" equ "%n2%" echo %n1% is equal to %n2%
exit /b

:padNum
setlocal enableDelayedExpansion
set "n=000000000000000!%~1!"
set "n=!n:~-15!"
endlocal & set "%~1=%n%"
exit /b