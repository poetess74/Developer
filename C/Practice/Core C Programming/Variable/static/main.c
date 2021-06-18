#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int get_gcd(int x, int y);
extern int get_factorial(int num);

int main() {
    srand((unsigned int) time(NULL));

    for (int i = 0; i < 5; i++) {
        int num = rand() % 10;
        printf("%2d! = %7d\n", num, get_factorial(num));
    }
    for (int i = 0; i <= 5; i++) {
        int a = rand() % 100;
        int b = rand() % 100;
        printf("%2d and %2d GCD = %2d\n", a, b, get_gcd(a, b));
    }
    return 0;
}
