#include <stdio.h>

const char*a = "char*a=%c%s%c;main(){printf(a,34,a,34);}";

int main() {
	printf(a, 34, a, 34);
}