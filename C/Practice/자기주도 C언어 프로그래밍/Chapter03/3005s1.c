#include <stdio.h>

int main() {
    int a, b;
    scanf("%d %d", &a, &b);
    int result1 = (a == b);
    int result2 = (a != b);
    printf("%d\n%d\n", result1, result2);
    return 0;
}
