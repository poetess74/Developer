#include <stdio.h>

int main() {
	int amount = 0, price = 0;
	const double VAT_RATE = 0.1;
	int total_price = 0;

	printf("input : ");
	scanf("%d", &amount);
	printf("input : ");
	scanf("%d", &price);

	total_price = amount * price * (1 + VAT_RATE);
	printf("sum = \\%d\n", total_price);

//  VAR_RATE = 0.15;
	
	return 0;
}
