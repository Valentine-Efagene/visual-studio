#include <stdio.h>
#include <windows.h>

int factorial(int n)
{
	__asm
	{
		mov eax, n
		mov ecx, eax
		mov ebx, 1

		loop_:
			cmp ecx, ebx
			je end_loop
			dec ecx
			mul ecx
			jmp loop_

		end_loop :
	}
}

void main()
{
	int n = 0;

	printf("n = ");
	scanf_s("%d" , &n);
	printf("%d! = %d\n", n, factorial(5));
	system("pause");
}