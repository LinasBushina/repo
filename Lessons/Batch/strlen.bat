@echo off
set str=abcd
echo %str% > lenfile.txt
for %%? in (lenfile.txt) do (
	set /a strlen=%%~z?
)
del lenfile.txt
echo %strlen%