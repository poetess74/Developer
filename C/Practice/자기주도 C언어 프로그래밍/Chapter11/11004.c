#include <stdio.h>

int Add(int x, int y) {
    return x + y;
}

int Sub(int x, int y) {
    int min = x - y;
    if (min < 0) {
        min *= -1;
    }
    return min;
}

int main() {
    int a, b, sum, sub;
    scanf("%d %d", &a, &b);
    sum = Add(a, b);
    sub = Sub(a, b);
    printf("두 수의 합 = %d\n", sum);
    printf("두 수의 차 = %d\n", sub);
    return 0;
}
