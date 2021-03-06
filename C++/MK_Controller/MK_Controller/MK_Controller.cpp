// SocketServer.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "MK_Controller_Helper.h"

int width = GetSystemMetrics(SM_CXSCREEN);
int height = GetSystemMetrics(SM_CYSCREEN);

uint32_t sizeArray[2] = { htonl(width), htonl(height) };

WSADATA wsaData;
int iResult;

int x, y;

SOCKET ListenSocket = INVALID_SOCKET;
SOCKET ClientSocket = INVALID_SOCKET;

struct addrinfo *result = NULL;
struct addrinfo hints;

int iSendResult;
char recvbuf[DEFAULT_BUFLEN];
int recvbuflen = DEFAULT_BUFLEN;

int setUpListener();
int createClient();
int loop();

int main()
{
	// No longer need server socket
	//closesocket(ListenSocket);
	printf("%d\n", width);
	printf("%d\n", height);
	setUpListener();
	createClient();
	loop();
	closesocket(ListenSocket);
}

int setUpListener()
{
	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		printf("WSAStartup failed with error: %d\n", iResult);
		return 1;
	}

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	// Resolve the server address and port
	iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
	if (iResult != 0) {
		printf("getaddrinfo failed with error: %d\n", iResult);
		WSACleanup();
		return 1;
	}

	// Create a SOCKET for connecting to server
	ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	if (ListenSocket == INVALID_SOCKET) {
		printf("socket failed with error: %ld\n", WSAGetLastError());
		freeaddrinfo(result);
		WSACleanup();
		return 1;
	}

	// Setup the TCP listening socket
	iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);
	if (iResult == SOCKET_ERROR) {
		printf("bind failed with error: %d\n", WSAGetLastError());
		freeaddrinfo(result);
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	freeaddrinfo(result);
	iResult = listen(ListenSocket, SOMAXCONN);

	if (iResult == SOCKET_ERROR) {
		printf("listen failed with error: %d\n", WSAGetLastError());
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	return 0;
}

int createClient()
{
	// Accept a client socket
	puts("Waiting for Client");
	ClientSocket = accept(ListenSocket, NULL, NULL);
	if (ClientSocket == INVALID_SOCKET) {
		printf("accept failed with error: %d\n", WSAGetLastError());
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	loop();
	return 0;
}

int loop()
{

	INPUT input = {};
	int scrollValue;

	// Receive until the peer shuts down the connection
	do {
		char a[DEFAULT_BUFLEN];
		char b[DEFAULT_BUFLEN];
		char button[DEFAULT_BUFLEN];

		for (int i = 0; i < DEFAULT_BUFLEN; i++) {
			a[i] = recvbuf[i] = b[i] = button[i] = '\n';
		}

		iResult = recv(ClientSocket, recvbuf, recvbuflen, 0);
		int n = 0;

		// Send the screen size
		char * c_size = (char *)calloc(ALLOCATION_FOR_SCREEN_SIZE, sizeof(int));
		sprintf_s(c_size, ALLOCATION_FOR_SCREEN_SIZE * sizeof(c_size), "%d %d\n", width, height);
		iSendResult = send(ClientSocket, c_size, ALLOCATION_FOR_SCREEN_SIZE * sizeof(c_size), 0);
		if (iSendResult == SOCKET_ERROR) {
			printf("send failed with error: %d\n", WSAGetLastError());
			closesocket(ClientSocket);
			createClient();
			WSACleanup();
			return 1;
		}

		if (iResult > 0) {

			if (contains(recvbuf, '~', DEFAULT_BUFLEN)) {
				if (contains(recvbuf, 'C', DEFAULT_BUFLEN)) {
					if (contains(recvbuf, '1', DEFAULT_BUFLEN)) {
						if (!GetKeyState(VK_CAPITAL)) {
							pressKey(VK_CAPITAL);
						}
					}
					else {
						if (GetKeyState(VK_CAPITAL)) {
							pressKey(VK_CAPITAL);
						}
					}

					continue;
				}
				
				for (char c : recvbuf) {
					if (c == '\n') {
						break;
					}
					else if (c >= '0' && c <= '9') {
						button[n] = c;
						n++;
					}
				}

				pressKey(toInt(button));
				continue;
			}

			for (char c : recvbuf) {
				if (c == '\n') {
					break;
				}
				else if (c >= '0' && c <= '9' || c == ' ' || c == '-') {
					a[n] = c;
					n++;
				}
			}

			for (char c : recvbuf) {
				if (c == '\n') {
					break;
				}

				if (c >= 'A' && c <= 'Z' || c == '~') {
					b[n] = c;
					n++;
				}
			}

			if (a[0] != '\n' && !contains(a, ' ', DEFAULT_BUFLEN)) {
				scrollValue = toInt(a);
				mouseScroll(input, scrollValue);
				continue;
			}
			
			if (a[0] != '\n' && contains(a, ' ', DEFAULT_BUFLEN)) {
				x = getWidth(a);
				y = getHeight(a);
				printf("Bytes received: %d\n", iResult);
				SetCursorPos(x, y);
				printf("%d %d\n", x, y);
				continue;
			}

			for (char c : b) {
				switch (c)
				{
				case 'A':
					mouseLeftClick(input);
					printf("%c\n", c);
					break;
				case 'B':
					mouseRightClick(input);
					printf("%c\n", c);
					break;
				case 'C':
					mouseLeftPress(input);
					printf("%c\n", c);
					break;
				case 'D':
					mouseLeftRelease(input);
					printf("%c\n", c);
					break;
				case 'E':
					mouseRightPress(input);
					printf("%c\n", c);
					break;
				case 'F':
					mouseRightRelease(input);
					printf("%c\n", c);
					break;
				case '\n':
					continue;
					break;
				default:
					break;
				}
			}
		}
		else if (iResult == 0) {
			printf("Connection closing...\n");
			closesocket(ClientSocket);
			createClient();
		}
		else {
			printf("recv failed with error: %d\n", WSAGetLastError());
			closesocket(ClientSocket);
			WSACleanup();
			return 1;
		}

	} while (iResult > 0);

	// shutdown the connection since we're done
	iResult = shutdown(ClientSocket, SD_SEND);
	if (iResult == SOCKET_ERROR) {
		printf("shutdown failed with error: %d\n", WSAGetLastError());
		closesocket(ClientSocket);
		WSACleanup();
		return 1;
	}


	// cleanup
	closesocket(ClientSocket);
	WSACleanup();

	return 0;
}