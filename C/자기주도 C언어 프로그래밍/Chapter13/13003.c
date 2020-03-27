#include <stdio.h>

int fac(int input) {
    if (input <= 1) {
        return 1;
    }
    return input * fac(input - 1);
}

int main() {
    int num;
    scanf("%d", &num);
    printf("%d\n", fac(num));
    return 0;
}
