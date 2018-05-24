@echo off
if not defined launchnum (
	set /a launchnum=0
)
set /a launchnum=%launchnum%+1
setlocal enabledelayedexpansion
del results.txt
set /a size = 0
if "%1"=="log" (
	for /f "tokens=*" %%i in ('set') do (
	@rem for /f "tokens=*" %%i in (testenv.txt) do (
		for /f "tokens=1,2 delims=^=" %%a in ("%%i") do (
			set arrname[!size!]=%%a
			set arrvalue[!size!]=%%b
		)
		set /a size = !size! + 1
	)
	set /a end_i = !size! - 2
	for /l %%i in (0, 1, !end_i!) do (
		set /a end_j = !size! - %%i - 2
		for /l %%j in (0, 1, !end_j!) do (
			set /a end_k = %%j + 1
			for /l %%k in (!end_k!, 1, !end_k!) do (
				if "%2"=="name" (
					if "%3"=="aplha" (
						if !arrname[%%j]! gtr !arrname[%%k]! (
							set tempname=!arrname[%%j]!
							set arrname[%%j]=!arrname[%%k]!
							set arrname[%%k]=!tempname!

							set tempvalue=!arrvalue[%%j]!
							set arrvalue[%%j]=!arrvalue[%%k]!
							set arrvalue[%%k]=!tempvalue!
						)
					)
					if "%3"=="length" (
    					echo !arrname[%%j]! > lenfile.txt
    					for %%? in (lenfile.txt) do (
							set /a strlenj=%%~z?
						)
						echo !arrname[%%k]! > lenfile.txt
    					for %%? in (lenfile.txt) do (
							set /a strlenk=%%~z?
						)
						del lenfile.txt

						set "strlenj=000!strlenj!"
						set "strlenj=!strlenj:~-3!"

						set "strlenk=000!strlenk!"
						set "strlenk=!strlenk:~-3!"

						if "!strlenj!" gtr "!strlenk!" (
							set tempname=!arrname[%%j]!
							set arrname[%%j]=!arrname[%%k]!
							set arrname[%%k]=!tempname!

							set tempvalue=!arrvalue[%%j]!
							set arrvalue[%%j]=!arrvalue[%%k]!
							set arrvalue[%%k]=!tempvalue!
						)
					)
				)
				if "%2"=="value" (
					if "%3"=="aplha" (
						if !arrvalue[%%j]! gtr !arrvalue[%%k]! (
							set tempname=!arrname[%%j]!
							set arrname[%%j]=!arrname[%%k]!
							set arrname[%%k]=!tempname!

							set tempvalue=!arrvalue[%%j]!
							set arrvalue[%%j]=!arrvalue[%%k]!
							set arrvalue[%%k]=!tempvalue!
						)
					)
					if "%3"=="length" (
    					echo !arrvalue[%%j]! > lenfile.txt
    					for %%? in (lenfile.txt) do (
							set /a strlenj=%%~z?
						)
						echo !arrvalue[%%k]! > lenfile.txt
    					for %%? in (lenfile.txt) do (
							set /a strlenk=%%~z?
						)
						del lenfile.txt

						set "strlenj=000!strlenj!"
						set "strlenj=!strlenj:~-3!"

						set "strlenk=000!strlenk!"
						set "strlenk=!strlenk:~-3!"

						if "!strlenj!" gtr "!strlenk!" (
							set tempname=!arrname[%%j]!
							set arrname[%%j]=!arrname[%%k]!
							set arrname[%%k]=!tempname!

							set tempvalue=!arrvalue[%%j]!
							set arrvalue[%%j]=!arrvalue[%%k]!
							set arrvalue[%%k]=!tempvalue!
						)
					)
				)
			)
		)
	)
	set /a end_i = !size! - 1
	for /l %%i in (0, 1, !end_i!) do (
		echo !arrname[%%i]!=!arrvalue[%%i]! >> results.txt
	)
)
if "%1"=="triangle" (
	if "%3"=="" (
		set /a triglen=!launchnum!-1
	)
	if not defined triglen (
		set /a triglen=%3-1
	)

	for /l %%i in (0, 1, !triglen!) do (
		for /l %%j in (0, 1, %%i) do (
			echo | set /p=%2 >> results.txt
		)
		echo. >> results.txt
	)

	set triglen=
)
endlocal
