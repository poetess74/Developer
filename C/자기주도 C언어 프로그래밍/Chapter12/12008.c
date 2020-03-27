#include <stdio.h>
#define multi(x, y) (x) * (y)

int main() {
    int a, b, c;
    scanf("%d %d", &a, &b);
    c = multi(a + 10, b - 5);
    printf("(%d + 10) * (%d - 5) = %d\n", a, b, c);
    return 0;
}
