#include <stdio.h>
#include <stdlib.h>

int main() {
	int S[10];
	int N = 0;
	int C = 0;
	int K = 1;

	printf("#] ");	
	scanf("%d", &N);

	if (N == 0 || N == 1) {
		exit(0);
	}

	do {
		if (N % K == 0) {
			printf("소수\n");
		} else {
			K = K + 1;
		}
	} while (K == 100);

	return 0;
}
