#include <iostream>
#include <windows.h>

using namespace std;
extern "C" double mean(long long a, long long int);
extern "C" long long int summation(long long a[], long long int);

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

	long long int length = n;
	long long int total = summation(A, length);
	double average = mean(total, length);

	cout << "SUM = " << total << endl;
	cout << "MEAN = " << average << endl;
	free(A);
	system("pause");
	return 0;
}