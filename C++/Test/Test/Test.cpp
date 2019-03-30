
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "stdafx.h"
#include "Source.h"

int getWidth(char a[]);
int getHeight(char a[]);
int toInt(char a[]);
bool contains(char a[512], char search, int arraySize);

int main()
{
	char a[15] = "1340 720";
	
	if (contains(a, ' ', 15 )) {
		puts("True");
	}
	else {
		puts("false");
	}

	getchar();
    return 0;
}

bool contains(char a[512], char search, int arraySize)
{
	for (int i = 0; i < arraySize; i++) {
		if (a[i] == search) {
			return true;
		}
	}

	return false;
}

int getWidth(char a[512])
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
