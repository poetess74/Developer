#include <stdio.h>

int get_factorial(int num);

int main() {
    for (int i = 0; i < 11; i++) {
        printf("%2d! = %7d\n", i, get_factorial(i));
    }
    return 0;
}

int get_factorial(int num) {
    if (num <= 1) {
        return 1;
    }
    return num * get_factorial(num - 1);
}
