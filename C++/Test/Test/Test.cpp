
#include <stdlib.h>
#include <string.h>
#include "stdafx.h"
#include "Source.h"

int getWidth(char a[]);
int getHeight(char a[]);
int toInt(char a[]);

int main()
{
	char a[15] = "1340 720";
	int w = 213323;
	char * c_size = (char *)calloc(20, sizeof(int));
	printf("%d", sizeof(c_size));
    return 0;
}

int getWidth(char a[])
{
	int c, offset = 0, n = 0;

	for (c = offset; a[c] >= '0' && a[c] <= '9'; c++)
	{
		n = n * 10 + a[c] - '0';
	}

	return n;
}

int getHeight(char a[])
{
	int c, offset = 0, i = 0, n = 0;

	while (a[i] != ' ') {
		offset = i + 2;
		i++;
	}

	for (c = offset; a[c] >= '0' && a[c] <= '9'; c++)
	{
		n = n * 10 + a[c] - '0';
	}

	return n;
}

int toInt(char a[])
{
	int c, sign, offset, n = 0;

	if (a[0] == '-')
	{
		sign = -1;
		offset = 1;
	}
	else
	{
		sign = 1;
		offset = 0;
	}

	for (c = offset; a[c] >= '0' && a[c] <= '9'; c++)
	{
		n = n * 10 + a[c] - '0';
	}

	n *= sign;
	return n;
}
