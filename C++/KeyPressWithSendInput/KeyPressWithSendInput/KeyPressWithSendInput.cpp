#define WINVER 0X0500
#include <windows.h>
#include <stdio.h>

void pressKey(int keyCode);
void mouseRightClick();
void mouseLeftClick();

int main()
{
	// Pause for 5 seconds
	Sleep(2000);
	mouseRightClick();
	getchar();
	return 0;
}

void pressKey(int keyCode)
{
	// This structure will be used to create the keyboard event
	INPUT ip;

	// Set up a generic keyboard event
	ip.type = INPUT_KEYBOARD;
	ip.ki.wScan = 0; //Hardware scan code for key
	ip.ki.time = 0;
	ip.ki.dwExtraInfo = 0;

	// Press the 'a' key
	ip.ki.wVk = keyCode; // Virtual key code for the 'a' key
	ip.ki.dwFlags = 0; // 0 for key press
	SendInput(1, &ip, sizeof(INPUT));

	// Release the 'a' key
	ip.ki.dwFlags = KEYEVENTF_KEYUP; // KEYEVENTF_KEYUP for key release
	SendInput(1, &ip, sizeof(INPUT));
}

void mouseRightClick()
{
	INPUT mouse;

	// Simulate press
	mouse.type = INPUT_MOUSE;
	mouse.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
	mouse.mi.time = 0;
	SendInput(1, &mouse, sizeof(INPUT));

	// Simulate release
	mouse.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseLeftClick()
{
	INPUT mouse;

	// Left down
	mouse.type = INPUT_MOUSE;
	mouse.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
	mouse.mi.time = 0;
	SendInput(1, &mouse, sizeof(INPUT));

	// Left up
	mouse.mi.dwFlags = MOUSEEVENTF_LEFTUP;
	SendInput(1, &mouse, sizeof(INPUT));
}