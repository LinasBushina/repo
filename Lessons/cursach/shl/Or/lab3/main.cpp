#include <iostream>
#include <cstdlib>

using namespace std;

extern "C" void get_output(int buffer);

void get_output(int buffer)
{
	char str[32];
	_itoa_s(buffer, str, 2);
	cout << str << endl;
}

