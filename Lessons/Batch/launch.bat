echo "1:"
call logtrig.bat log name length
type result.txt
TIMEOUT /T 10 /NOBREAK 
del result.txt
echo "2:"
call logtrig.bat log value alpha
type result.txt
TIMEOUT /T 10 /NOBREAK 
del result.txt
echo "3:"
call logtrig.bat triangle x 3 length
type result.txt
TIMEOUT /T 10 /NOBREAK 
del result.txt
echo "4:"
call logtrig.bat triangle v 8
type result.txt
TIMEOUT /T 10 /NOBREAK 
del result.txt