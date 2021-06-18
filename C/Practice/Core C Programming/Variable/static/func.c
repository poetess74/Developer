#include <stdio.h>

int get_gcd(int x, int y) {
    int r;
    while (y != 0) {
        r = x % y;
        x = y;
        y = r;
    }
    return x;
}

extern int get_factorial(int num) {
    int result = 1;

    for (int i = 1; i <= num; i++) {
        result *= i;
    }

    return result;
}
