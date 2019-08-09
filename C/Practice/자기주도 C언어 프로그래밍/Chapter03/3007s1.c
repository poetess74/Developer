#include<stdio.h>

int main() {
    int a, b;
    scanf("%d %d", &a, &b);
    int res1 = (a && b);
    int res2 = (a || b);
    printf("%d %d\n", res1, res2);
    return 0;
}
