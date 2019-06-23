#include <iostream>
#include <windows.h>

using namespace std;
extern "C" double mean(long long a, long long int);
extern "C" long long int summation(long long a[], long long int);

int main()
{
	long long int A[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	long long int length = sizeof(A) / sizeof(long long int);
	long long int total = summation(A, length);
	double average = mean(total, length);

	cout << "SUM = " << total << endl;
	cout << "MEAN = " << average << endl;

	system("pause");
	return 0;
}