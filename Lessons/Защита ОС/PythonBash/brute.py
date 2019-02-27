from subprocess import Popen
batch = 'brute.bat'
#code = r'"C:\Program Files (x86)\WinRAR\Rar.exe" x ar.rar . -y -p'
code = r'"C:\Program Files\WinRAR\Rar.exe" x ar.rar . -y -p'

for d in range(1,5,1):
	for i in range(10 ** d):
		pswd = str(i).zfill(d)
		curr_code = code + pswd
		with open(batch , 'w') as f:
			f.write(curr_code)
		p = Popen(batch , cwd=r'.')
		p.communicate()
		ret = int(p.returncode)
		p.kill()
		if ret == 0:
			print('Pass:', pswd)
			break