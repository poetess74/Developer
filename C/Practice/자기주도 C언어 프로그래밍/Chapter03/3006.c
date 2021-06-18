#include <stdio.h>

int main() {
    int a, b, c;
    scanf("%d %d %d", &a, &b, &c);
    int result1 = (a > b);
    int result2 = (b >= c);
    int result3 = (a <= b);
    int result4 = (b < c);
    printf("%d %d %d %d\n", result1, result2, result3, result4);
    return 0;
}
