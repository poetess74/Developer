#include <stdio.h>

int main() {
    int a, b;
    scanf("%d %d", &a, &b);
    int res1 = (a > b);
    int res2 = (a < b);
    int res3 = (a >= b);
    int res4 = (a <= b);
    printf("%d > %d --- %d\n%d < %d --- %d\n%d >= %d --- %d\n%d <= %d --- %d\n", a, b, res1, a, b, res2, a, b, res3, a, b, res4);
    return 0;
}
