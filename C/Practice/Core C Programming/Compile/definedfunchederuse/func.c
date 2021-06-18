#include <stdio.h>
#include "func.h"

int get_factorial(int num) {
    int result = 1;
    for (int i = 1; i <= num; i++) {
        result *= i;
    }
    return result;
}

int get_gcd(int x, int y) {
    int r;
    while (y != 0) {
        r = x % y;
        x = y;
        y = r;
    }
    return x;
}

int get_max(int a, int b, int c) {
    int max = a > b ? a : b;
    max = c > max ? c : max;
    return max;
}

void print_array(const int array[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%2d ", array[i]);
    }
    printf("\n");
}
