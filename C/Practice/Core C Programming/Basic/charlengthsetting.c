#include <stdio.h>

int main() {
		int num = 12345;
		printf("%d\n", num);
		printf("%d\n", num * 10);
		printf("%d\n", num * 100);
		printf("%d\n", num * 1000);

		printf("%8d\n", num);
		printf("%8d\n", num * 10);
		printf("%8d\n", num * 100);
		printf("%8d\n", num * 1000);
		printf("%8d\n", num * 10000);

		printf("%08d\m", num);

		return 0;
}
