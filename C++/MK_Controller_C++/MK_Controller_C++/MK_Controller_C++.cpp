// MK_Controller_C++.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <Windows.h>

HANDLE hStdIn;
DWORD fdwSaveOldMode;

void keyEventProc(KEY_EVENT_RECORD);
void mouseEventProc(MOUSE_EVENT_RECORD);
void gotoxy(int, int);
void errorExit(LPCSTR lpcszMessage);

int main()
{
	DWORD cNumRead, fdwMode, i;
	INPUT_RECORD irInBuf[128];
	int counter = 0;
	Sleep(5000);
	gotoxy(1000, 700);

	//Get standard input handle.

	hStdIn = GetStdHandle(STD_INPUT_HANDLE);
	
	if (hStdIn == INVALID_HANDLE_VALUE)
	{
		errorExit("GetStdHandle");
	}

	if (! GetConsoleMode(hStdIn, &fdwSaveOldMode))
	{
		errorExit("GetConsoleMode");
	}

	fdwMode = ENABLE_WINDOW_INPUT | ENABLE_MOUSE_INPUT;
	
	if (!SetConsoleMode(hStdIn, fdwMode))
	{
		errorExit("SetConsoleMode");
	}

	while (true)
	{
		if (! ReadConsoleInput(
				hStdIn,			// input buffer handle
				irInBuf,		//buffer to read into
				128,			//size of read buffer
				&cNumRead ) )	//number of records read
		{
			errorExit("ReadConsoleInput");
		}

		for(i = 0; i < cNumRead; i++) 
		{
			switch (irInBuf[i].EventType)
			{
			case KEY_EVENT:
				keyEventProc(irInBuf[i].Event.KeyEvent);
				break;
			default:
				break;
			}
		}

		counter++;

		if (counter == 5)
		{
			errorExit("Done");
		}
	}

	SetConsoleMode(hStdIn, fdwSaveOldMode);

	return 0;
}

void gotoxy(int x, int y)
{
	SetCursorPos(x, y);
}

void errorExit(LPCSTR lpcszMessage)
{
	fprintf(stderr, "%s\n", lpcszMessage);
	SetConsoleMode(hStdIn, fdwSaveOldMode);
	ExitProcess(0);
}

void keyEventProc(KEY_EVENT_RECORD ker)
{
	printf("Key Event: ");
	if (ker.bKeyDown)
	{
		printf("Key Pressed\n");
	}
	else
	{
		printf("Key Released\n");
	}
}