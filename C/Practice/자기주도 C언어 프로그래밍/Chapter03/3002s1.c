#include <stdio.h>

int main() {
    int a, b;
    scanf("%d %d", &a, &b);
    a += 100; b %= 10;
    printf("%d %d\n", a, b);
    return 0;
}
