import re
import sys
import os.path
import win32com.client #pip install pywin32
from subprocess import Popen

def main():
	if len(sys.argv) != 2:
		print('Need one argument - drive path', file=sys.stderr)
		return
	drive_path = sys.argv[1]
	autorun_path = os.path.join(drive_path, 'autorun.inf')
	exists = os.path.isfile(autorun_path)
	if not exists:
		print('Missing autorun.inf', file=sys.stderr)
		return
	print('autorun.inf found')
	virus_path = None
	with open(autorun_path, 'r') as f:
		for l in f:
			m = re.search(r'OPEN=(.*)$', l)
			if m != None:
				virus_path = os.path.abspath(\
					os.path.join(drive_path, m.groups()[0]))
				print(virus_path, '- virus file name found')
				break
		else:
			print('Missing OPEN directive in autorun.inf',
				file=sys.stderr)
			return
	shell = win32com.client.Dispatch('WScript.Shell')
	with os.scandir(drive_path) as it:
		for f in it:
			m = re.search('^(.*)\.lnk$', f.name)
			if f.is_file() and m != None:
				shortcut = shell.CreateShortCut(f.path)
				if shortcut.Targetpath == virus_path:
					p = Popen(['autorun_antivirus.bat',
						os.path.abspath(os.path.join(drive_path,
							m.groups()[0]))], cwd=r'.')
					p.communicate()
					p.wait()
					os.remove(f.path)
					print(f.path, '- infected lnk cured')
	os.remove(autorun_path)
	print('autorun.inf removed')
	os.remove(virus_path)
	print(virus_path, '- virus file removed')
if __name__ == '__main__':
	main()