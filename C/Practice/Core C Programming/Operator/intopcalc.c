#include <stdio.h>

int main() {
	int x = 0, y = 0;

	printf("input : ");
	scanf("%d %d", &x, &y);

	printf("+%d = %d\n", x, +x);
	printf("-%d = %d\n", y, -y);
	printf("%d + %d = %d\n", x, y, x + y);
	printf("%d - %d = %d\n", x, y, x - y);
	printf("%d * %d = %d\n", x, y, x * y);
	printf("%d / %d = %d\n", x, y, x / y);
	printf("%d %% %d = %d\n", x, y, x % y);

	return 0;
}
