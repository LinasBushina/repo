@echo off
echo "1:"
call logtrig.bat log name length
TIMEOUT /T 10 /NOBREAK
echo "2:"
call logtrig.bat log value alpha
TIMEOUT /T 10 /NOBREAK 
echo "3:"
call logtrig.bat triangle x 3 length
TIMEOUT /T 10 /NOBREAK
echo "4:"
call logtrig.bat triangle v 8
TIMEOUT /T 10 /NOBREAK