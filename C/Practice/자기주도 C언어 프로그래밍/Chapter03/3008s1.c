#include <stdio.h>

int main() {
    int a, b, c;
    scanf("%d %d %d", &a, &b, &c);
    int res1 = (a > b && a > c);
    int res2 = (a == b && b == c);
    printf("%d %d\n", res1, res2);
    return 0;
}
