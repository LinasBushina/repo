@echo off
setlocal enabledelayedexpansion 
set /a size = 0
if "%1"=="log" (
	@rem for /f "tokens=*" %%i in ('set') do (
	for /f "tokens=*" %%i in (testenv.txt) do (
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
    					echo !arrname[%%j]!
						set jstr=!arrname[%%j]!
						set jlen=0
						:loop
    					if defined jstr (set jstr=!jstr:~1!& set /a jlen+=1 & goto:loop)
    					
    					@rem echo !arrname[%%j]!=!jlen!
					)
				)
				if "%2"=="value" (
					if !arrvalue[%%j]! gtr !arrvalue[%%k]! (
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
	set /a end_i = !size! - 1
	for /l %%i in (0, 1, !end_i!) do (
		echo !arrname[%%i]!=!arrvalue[%%i]!
	)
)
endlocal
