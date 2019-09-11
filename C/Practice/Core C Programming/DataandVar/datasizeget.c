#include <stdio.h>

int main() {
	char ch;
	int num;
	double x;

	printf("char bite size : %d\n", sizeof(char));

	printf("short bite size : %d\n", sizeof(short));
	printf("int bite size : %d\n", sizeof(int));
	printf("long bite size : %d\n", sizeof(long));
	printf("long long bite size : %d\n", sizeof(long long));

	printf("float bite size : %d\n", sizeof(float));
	printf("double bite size : %d\n", sizeof(double));
	printf("long double bite size : %d\n", sizeof(long double));

	printf("ch bite size : %d\n", sizeof ch);
	printf("num bite size : %d\n", sizeof num);
	printf("x bite size : %d\n", sizeof x);

	return 0;
}
