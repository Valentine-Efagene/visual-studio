
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "stdafx.h"
#include "Source.h"
#include <iostream>

using namespace std;

int main() 
{
	int n;
	cout << "Length of array = ";
	cin >> n;

	long long * A = (long long *) malloc(n * sizeof(long long));

	cout << "Enter" << n << " integers" << endl;
	
	for (int i = 0; i < n; i++) {
		cout << i + 1 << ": ";
		cin >> A[i];
	}

	//cout << *(A + 1);

	for (int i = 0; i < n; i++) {
		cout << A[i] << " ";
	}

	free(A);
}