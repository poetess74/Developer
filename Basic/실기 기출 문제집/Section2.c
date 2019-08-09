#include <stdio.h>

int main() {
	int i = 0;
	int j = 0;

	do {
		i = i + 1;
		j = j + i;
	} while (i < 7); 

	printf("%d\t%d\n", i, j);
	return 0;
}
