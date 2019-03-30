#pragma once
#undef UNICODE

#define WIN32_LEAN_AND_MEAN
#define WINVER 0X0500

#include <iostream>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <stdio.h>
#include <windows.h>

// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
// #pragma comment (lib, "Mswsock.lib")

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "12324"
#define ALLOCATION_FOR_SCREEN_SIZE 20

int getWidth(char a[]);
int getHeight(char a[]);
int toInt(char a[]);
bool contains(char a[DEFAULT_BUFLEN], char search);
void pressKey(int keyCode);
void mouseRightClick(INPUT mouse);
void mouseLeftClick(INPUT mouse);
void mouseLeftPress(INPUT mouse);
void mouseLeftRelease(INPUT mouse);
void mouseRightPress(INPUT mouse);
void mouseRightRelease(INPUT mouse);
void mouseScroll(INPUT, int);

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

void mouseRightClick(INPUT mouse)
{
	// Simulate press
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
	mouse.mi.time = 0;
	SendInput(1, &mouse, sizeof(INPUT));

	// Simulate release
	mouse.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseLeftPress(INPUT mouse)
{
	// Simulate press
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.time = 0;
	mouse.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseLeftRelease(INPUT mouse)
{
	// Simulate release
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.time = 0;
	mouse.mi.dwFlags = MOUSEEVENTF_LEFTUP;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseRightPress(INPUT mouse)
{
	// Simulate press
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
	mouse.mi.time = 0;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseRightRelease(INPUT mouse)
{
	// Simulate release
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.time = 0;
	mouse.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseLeftClick(INPUT mouse)
{
	// Left down
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
	mouse.mi.time = 0;
	SendInput(1, &mouse, sizeof(INPUT));

	// Left up
	mouse.mi.dwFlags = MOUSEEVENTF_LEFTUP;
	SendInput(1, &mouse, sizeof(INPUT));
}

void mouseScroll(INPUT mouse, int value) {
	// Simulate scroll
	ZeroMemory(&mouse, sizeof(INPUT));
	mouse.type = INPUT_MOUSE;
	mouse.mi.dwFlags = MOUSEEVENTF_WHEEL;
	mouse.mi.time = 0;
	mouse.mi.mouseData = WHEEL_DELTA * value;
	SendInput(1, &mouse, sizeof(INPUT));
}

bool contains(char a[DEFAULT_BUFLEN], char search, u_int arraySize) 
{
	for (int i = 0; i < arraySize; i++) {
		if (a[i] == search) {
			return true;
		}
	}

	return false;
}