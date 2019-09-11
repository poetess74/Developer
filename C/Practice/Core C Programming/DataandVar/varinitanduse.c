#include <stdio.h>

int main() {
	int amount;
	int price = 0;
	int total_price = 0;

	printf("amount = %d, price = %d\n", amount, price);

	printf("input : ");
	scanf("%d", &amount);
	price = 2000;

	total_price = amout * price;
	printf("sum ; \\%d\n", total_price);

	return 0;
}
