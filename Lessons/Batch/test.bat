@echo off
setlocal

set "str=string1&with spaces by string2&with spaces.txt"

set "string1=%str: by =" & set "string2=%"
set "string2=%string2:.txt=%"

echo "%string1%"
echo "%string2%"