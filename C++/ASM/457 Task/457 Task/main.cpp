#include <iostream>

using namespace std;

extern "C" int inProc()
{
	int num;
	cout << "Enter: ";
	cin >> num;
	return num;
}

extern "C" void outProc(int num)
{
	cout << num << endl;
	cout << "Input any character, then press 'Enter' to Exit!" << endl;
	cin >> num;
}
	