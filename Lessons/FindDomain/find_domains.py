import re

text = \
"""
Hello, my friend, text me at gibson.mail.com and
my cherrie at ketty.gmail.net bla bla bla
i like site cats.ru and wikipedia.org
marko-polo.com
xn--h1aaf0ab0e.com
aa.com
a-b.com
a-.com
a--b.com
a--bd.com
ab--d.com
moloko--corova.com
lemon.biz
aa.bb.com
aa.bb.cc.com
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.com
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.com
"""

c = r'[a-zA-Z0-9]'
h = r'[a-zA-Z0-9-]'
n = r'[^a-zA-Z0-9-.]'
domain = '(' + c + c + '|' +\
		c + h + '{1,2}' + c + '|' +\
		c + h + '(' + c + h + '|' + h + c + ')' + h + '{0,58}' + c + ')'
pattern = '(' + n + '|^)' + '(' +\
			'(' + domain + r'\.)?' + domain +\
	        r'\.(ru|org|com|net))' + '(' + n + '|$)'
print(text)
print('pattern :', pattern, '\n')
for match in re.finditer(pattern, text, re.M):
	print(match.group(2))
