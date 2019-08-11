#include <stdio.h>

void get_sum_product(int x, int y, int *sum, int *product);

int main() {
    int result1, result2;

    get_sum_product(10, 20, &result1, &result2);
    printf("sum = %d, product = %d\n", result1, result2);
    return 0;
}

void get_sum_product(int x, int y, int *sum, int *product) {
    *sum = x + y;
    *product = x * y;
}
