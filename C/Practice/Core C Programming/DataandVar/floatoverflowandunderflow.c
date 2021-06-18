#include <stdio.h>

int main() {
	float x = 3.40282e38f;
	float y = 1.17549e-38f;

	printf("x = %30.25e\n", x);
	printf("y = %30.25e\n", y);

	x = x * 100;
	printf("x = %30.25e\n", x);

	y = y / 1000;
	printf("y = %30.25e\n", y);
	y = y / 1000;
	printf("y = %30.25e\n", y);
	y = y / 1000;
	printf("y = %30.25e\n", y);

	return 0;
}
