#include <iostream>

using namespace std;
extern "C" int addInts(int a, int b);

int main()
{
	// initialise two variables for the addition
	int a = 0, b = 0;
	// Prompt user for first integer
	cout << "Enter first integer: ";
	// Receive first integer from the user
	cin >> a;
	// Prompt user for first integer
	cout << "Enter second integer: ";
	// Receive second integer from the user
	cin >> b;
	// Display the result
	cout << "sum = " << addInts(a, b) << endl;
	// Pause for the user to view the output
	system("pause");
}
