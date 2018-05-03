#include <chrono>
using namespace std;

extern "C" int* create_arr(int size);
extern "C" int get_time();

int* create_arr(int size)
{
	int *arr = new int[size];
	for (int i = 0; i < size; i++)
	{ arr[i] = size - i; }
	return arr;
}

int get_time()
{
	auto now_time = chrono::high_resolution_clock::now();
	int res = chrono::duration_cast<chrono::milliseconds>(now_time.time_since_epoch()).count();
	return res;
}