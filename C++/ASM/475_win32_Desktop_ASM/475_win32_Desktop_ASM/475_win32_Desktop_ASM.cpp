// 475_win32_Desktop_ASM.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "475_win32_Desktop_ASM.h"

#define MAX_LOADSTRING 100
#define ID_BUTTON_ADD 0X8801
#define ID_BUTTON_SUBTRACT 0X8802
#define ID_BUTTON_MULTIPLY 0X8803
#define ID_BUTTON_DIVIDE 0X8804
#define ID_EDIT_FIRST_OPERAND 0X8805
#define ID_EDIT_SECOND_OPERAND 0X8806
#define ID_EDIT_RESULT 0X8807
#define ID_EDIT_RESULT_REMAINDER 0X8808

void add(HWND, HWND, HWND, HWND);
void subtract(HWND, HWND, HWND, HWND);
void multiply(HWND, HWND, HWND, HWND);
void divide(HWND, HWND, HWND, HWND, HWND);

extern "C" int addInts(int a, int b);
extern "C" int subtractInts(int a, int b);
extern "C" int multiplyInts(int a, int b);
extern "C" int quotientInts(int a, int b);
extern "C" int remainderInts(int a, int b);

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

HFONT hfDefault;
HWND h_Edit_first_operand;
HWND h_Edit_second_operand;
HWND h_Edit_result;
HWND h_Edit_remainder;
HWND h_Button_add;
HWND h_Button_subtract;
HWND h_Button_multiply;
HWND h_Button_divide;

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_MY475WIN32DESKTOPASM, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY475WIN32DESKTOPASM));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY475WIN32DESKTOPASM));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+2); // cHANGE THE INTEGER OFFSET TO CHANGE THE COLOUR
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_MY475WIN32DESKTOPASM);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(
	   szWindowClass,
	   szTitle,
	   WS_OVERLAPPEDWINDOW,
       CW_USEDEFAULT,
	   0,
	   400,
	   300, 
	   nullptr,
	   nullptr,
	   hInstance,
	   nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
			case ID_BUTTON_ADD:
				add(h_Edit_first_operand, h_Edit_second_operand, h_Edit_result, hWnd);
				break;
			case ID_BUTTON_SUBTRACT:
				subtract(h_Edit_first_operand, h_Edit_second_operand, h_Edit_result, hWnd);
				break;
			case ID_BUTTON_MULTIPLY:
				multiply(h_Edit_first_operand, h_Edit_second_operand, h_Edit_result, hWnd);
				break;
			case ID_BUTTON_DIVIDE:
				divide(h_Edit_first_operand, h_Edit_second_operand, h_Edit_result, h_Edit_remainder, hWnd);
				break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
    case WM_PAINT:
        {
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            // TODO: Add any drawing code that uses hdc here...
            EndPaint(hWnd, &ps);
        }
        break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
	case WM_CREATE:
	{
		h_Edit_first_operand = CreateWindowEx(WS_EX_CLIENTEDGE, L"EDIT", L"",
			WS_CHILD | WS_VISIBLE | ES_NUMBER,
			20, 20, 50, 50, hWnd, NULL, GetModuleHandle(NULL), NULL);
		if (h_Edit_first_operand == NULL)
			MessageBox(hWnd, L"Could not create first edit box.", L"Error", MB_OK | MB_ICONERROR);
		
		h_Edit_second_operand = CreateWindowEx(WS_EX_CLIENTEDGE, L"EDIT", L"",
			WS_CHILD | WS_VISIBLE | ES_NUMBER,
			80, 20, 50, 50, hWnd, NULL, GetModuleHandle(NULL), NULL);
		if (h_Edit_first_operand == NULL)
			MessageBox(hWnd, L"Could not create second edit box.", L"Error", MB_OK | MB_ICONERROR);

		h_Edit_result = CreateWindowEx(WS_EX_CLIENTEDGE,
			L"EDIT", // Predefined class ; Unicode assumed
			L"", // Content
			WS_CHILD | WS_VISIBLE | WS_HSCROLL, // Styles
			140, // x position
			20, // y position
			100, // Width
			50, // Height
			hWnd, // Parent Window
			NULL, // Menu
			GetModuleHandle(NULL),
			NULL); // Pointer not needed
		if (h_Edit_first_operand == NULL)
			MessageBox(hWnd, L"Could not create result edit box.", L"Error", MB_OK | MB_ICONERROR);


		h_Edit_remainder = CreateWindowEx(WS_EX_CLIENTEDGE,
			L"EDIT", // Predefined class ; Unicode assumed
			L"REMAINDER", // Content
			WS_CHILD | WS_VISIBLE | WS_HSCROLL, // Styles
			260, // x position
			20, // y position
			100, // Width
			50, // Height
			hWnd, // Parent Window
			NULL, // Menu
			GetModuleHandle(NULL),
			NULL); // Pointer not needed
		if (h_Edit_first_operand == NULL)
			MessageBox(hWnd, L"Could not create remainder edit box.", L"Error", MB_OK | MB_ICONERROR);

		h_Button_add = CreateWindowEx(WS_EX_CLIENTEDGE, L"BUTTON", L"+",
			WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | WS_TABSTOP,
			20, 100, 50, 50, hWnd, (HMENU) ID_BUTTON_ADD, GetModuleHandle(NULL), NULL);
		if (h_Button_add == NULL)
			MessageBox(hWnd, L"Could not create addition button.", L"Error", MB_OK | MB_ICONERROR);

		h_Button_subtract = CreateWindowEx(WS_EX_CLIENTEDGE, L"BUTTON", L"-",
			WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | WS_TABSTOP,
			80, 100, 50, 50, hWnd, (HMENU)ID_BUTTON_SUBTRACT, GetModuleHandle(NULL), NULL);
		if (h_Button_subtract == NULL)
			MessageBox(hWnd, L"Could not create subtraction button.", L"Error", MB_OK | MB_ICONERROR);

		h_Button_multiply = CreateWindowEx(WS_EX_CLIENTEDGE,
			L"BUTTON", // Predefined class ; Unicode assumed
			L"x", // Content
			WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | WS_TABSTOP, // Styles
			140, // x position
			100, // y position
			50, // Width
			50, // Height
			hWnd, // Parent Window
			(HMENU)ID_BUTTON_MULTIPLY, // Menu
			GetModuleHandle(NULL),
			NULL); // Pointer not needed

		if (h_Button_multiply == NULL)
			MessageBox(hWnd, L"Could not create multiplication button.", L"Error", MB_OK | MB_ICONERROR);

		h_Button_divide = CreateWindowEx(WS_EX_CLIENTEDGE,
			L"BUTTON", // Predefined class ; Unicode assumed
			L"/", // Content
			WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | WS_TABSTOP, // Styles
			200, // x position
			100, // y position
			50, // Width
			50, // Height
			hWnd, // Parent Window
			(HMENU)ID_BUTTON_DIVIDE, // Menu
			GetModuleHandle(NULL),
			NULL); // Pointer not needed

		if (h_Button_divide == NULL)
			MessageBox(hWnd, L"Could not create division button.", L"Error", MB_OK | MB_ICONERROR);
	}
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}

void add(HWND hwnd_edit1, HWND hwnd_edit2, HWND hwnd_edit_res, HWND hwnd_parent)
{
	int val1 = 0, val2 = 0, sum = 0;
	int len = GetWindowTextLength(hwnd_edit1);

	if (len > 0)
	{
		int i = 0;
		LPWSTR buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit1, buf, len + 1);
		val1 = _wtoi(buf);
		GlobalFree((HANDLE)buf);

		i = 0;
		buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit2, buf, len + 1);

		val2 = _wtoi(buf);

		GlobalFree((HANDLE)buf);

		sum = addInts(val1, val2);
		TCHAR szBuffer[20];
		wsprintf(szBuffer, TEXT("%d"), sum);
		// MessageBox(hwnd_parent, szBuffer, L"Error", MB_OK | MB_ICONERROR);
		SendMessage(hwnd_edit_res, WM_SETTEXT, 0, (LPARAM)szBuffer);
	}
}

void subtract(HWND hwnd_edit1, HWND hwnd_edit2, HWND hwnd_edit_res, HWND hwnd_parent)
{
	int val1 = 0, val2 = 0, difference = 0;
	int len = GetWindowTextLength(hwnd_edit1);

	if (len > 0)
	{
		int i = 0;
		LPWSTR buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit1, buf, len + 1);
		val1 = _wtoi(buf);
		GlobalFree((HANDLE)buf);

		i = 0;
		buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit2, buf, len + 1);

		val2 = _wtoi(buf);

		GlobalFree((HANDLE)buf);

		difference = subtractInts(val1, val2);
		TCHAR szBuffer[20];
		wsprintf(szBuffer, TEXT("%d"), difference);
		// MessageBox(hwnd_parent, szBuffer, L"Error", MB_OK | MB_ICONERROR);
		SendMessage(hwnd_edit_res, WM_SETTEXT, 0, (LPARAM)szBuffer);
	}
}

void multiply(HWND hwnd_edit1, HWND hwnd_edit2, HWND hwnd_edit_res, HWND hwnd_parent)
{
	int val1 = 0, val2 = 0, product = 0;
	int len = GetWindowTextLength(hwnd_edit1);

	if (len > 0)
	{
		int i = 0;
		LPWSTR buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit1, buf, len + 1);
		val1 = _wtoi(buf);
		GlobalFree((HANDLE)buf);

		i = 0;
		buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit2, buf, len + 1);

		val2 = _wtoi(buf);


		GlobalFree((HANDLE)buf);

		product = multiplyInts(val1, val2);
		TCHAR szBuffer[20];
		wsprintf(szBuffer, TEXT("%d"), product);
		// MessageBox(hwnd_parent, szBuffer, L"Error", MB_OK | MB_ICONERROR);
		SendMessage(hwnd_edit_res, WM_SETTEXT, 0, (LPARAM)szBuffer);
	}
}

void divide(HWND hwnd_edit1, HWND hwnd_edit2, HWND hwnd_edit_res, HWND hwnd_edit_remainder, HWND hwnd_parent)
{
	int val1 = 0, val2 = 0;
	int quotient = 0;
	int len = GetWindowTextLength(hwnd_edit1);

	if (len > 0)
	{
		int i = 0;
		LPWSTR buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit1, buf, len + 1);
		val1 = _wtoi(buf);
		GlobalFree((HANDLE)buf);

		i = 0;
		buf;

		buf = (LPWSTR)GlobalAlloc(GPTR, len + 1);
		GetWindowText(hwnd_edit2, buf, len + 1);

		val2 = _wtoi(buf);

		GlobalFree((HANDLE)buf);

		quotient = quotientInts(val1, val2);
		TCHAR szBuffer[20];
		wsprintf(szBuffer, TEXT("%d"), quotient);
		SendMessage(hwnd_edit_res, WM_SETTEXT, 0, (LPARAM)szBuffer);

		int remainder = remainderInts(val1, val2);
		szBuffer[20];
		wsprintf(szBuffer, TEXT("%d"), remainder);
		SendMessage(hwnd_edit_remainder, WM_SETTEXT, 0, (LPARAM)szBuffer);
	}
}
