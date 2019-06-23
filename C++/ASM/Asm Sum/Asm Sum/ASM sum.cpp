#include <stdio.h>
void display();

char format[] = "%s %s\n";
char hello[] = "hello";
char world[] = "world";

int main()
{
	display();
}

void display()
{
	__asm
	{
		mov eax, offset world
		push eax
		mov eax, offset hello
		push eax
		mov eax, offset format
		push eax
		call printf
		pop ebx
		pop ebx
		pop ebx
	}
}