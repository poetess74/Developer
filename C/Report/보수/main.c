#include <stdio.h>

int main() {
	int a, b, c;
	int min, mid, max;

	scanf("%d %d %d", &a, &b, &c);

	min = (a < b) ? ((a < c) ? a : c) : ((b < c) ? b : (a < c) ? a : c);
	max = (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : (a > c) ? a : c);
	// 세 수간 크기 비교를 이용하여 중간수 구하는 방법
	mid = (a > b) ? ((a < c) ? a : ((b > c) ? b : c)) : ((b < c) ? b : (a > c) ? a : c); 
	// 이미 구한 min, max를 활용하여 중간수 구하는 방법
	//mid = (a != min && a != max) ? a : (b != min && b != max) ? b : c;
	// 이미 구한 min, max를 활용하여 비교문 없이 중간수 구하는 방법
	//mid = (a + b + c) - (min + max);

	printf("MAX : %d, MID : %d, MIN : %d\n", max, mid, min);

	return 0;
}
