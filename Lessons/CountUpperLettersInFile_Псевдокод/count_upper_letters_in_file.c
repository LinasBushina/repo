#include <stdio.h>

int main()
{
	FILE *file = fopen("sample.txt", "r");

	int count = 0;
	char ch;
	while((ch = getc(file)) != EOF)
    { if (ch >= 'A' && ch <= 'Z') count++; }
	printf("%d\n", count);
}
