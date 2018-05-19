@echo off
setlocal enabledelayedexpansion 
set /a size = 0
if "%1"=="log" (
	for /f "tokens=*" %%i in ('set') do (
		for /f "tokens=1,2 delims=^=" %%a in ("%%i") do (
			set arr[!size!].name = %%a
			set arr[!size!].value = %%b
		)
		set /a size = !size! + 1
	  	@rem echo !arr[!size!]!
	)
	set arr
)
endlocal