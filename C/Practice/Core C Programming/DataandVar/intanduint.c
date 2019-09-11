#include <stdio.h>

int main() {
	short a = -10;
	unsigned short b = 65526;

	printf("a = %d, %08x\n", a, a);
	printf("b = %d, %08x\n", b, b);

	return 0;
}
