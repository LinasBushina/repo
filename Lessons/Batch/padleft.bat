@echo off
set /a x=78
set "x=000000000!%x%!"
set "x=%x:~-10%"
echo %x%
endlocal