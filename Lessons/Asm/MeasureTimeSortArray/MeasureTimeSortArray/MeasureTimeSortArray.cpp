#include "stdafx.h"
#include <iostream>
#include <chrono>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int size = 1000;
	int *arr = new int[size];
	for (int i = 0; i < size; i++)
	{ arr[i] = size - i; }
	for (int i = 0; i < 10 && i < size; i++)
	{ printf("%d ", arr[i]); }
	printf("\n");
	auto start_time = chrono::high_resolution_clock::now();
	int start_time_int = chrono::duration_cast<chrono::nanoseconds>(start_time.time_since_epoch()).count();
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size - 1; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				int t = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = t;
			}
		}
	}
	auto end_time = std::chrono::high_resolution_clock::now();
	int end_time_int = chrono::duration_cast<chrono::nanoseconds>(end_time.time_since_epoch()).count();
	delete[] arr;
	/*auto used_time = end_time - start_time;
	long long used_time_l = chrono::duration_cast<chrono::nanoseconds>(used_time).count();
	printf("%lld\n", used_time_l);*/
	printf("%d\n", end_time_int - start_time_int);

	return 0;
}
