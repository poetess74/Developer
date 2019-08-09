#include <stdio.h>

int a, b, sum, times;

void input() {
    printf("두 수를 입력하세요 ");
    scanf("%d %d", &a, &b);
}

void clac() {
    sum = a + b;
    times = a * b;
}

void output() {
    printf("합 : %d\n", sum);
    printf("곱 : %d\n", times);
}

int main() {
    input();
    clac();
    output();
    return 0;
}
