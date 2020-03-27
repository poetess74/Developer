#include <stdio.h>

int main() {
    int a, b;
    scanf("%d %d", &a, &b);
    printf("%d %.2lf\n", a / b, (double)a / b);
    return 0;
}
