#include <stdio.h>

int main() {
    int a = 0, b = 1, c = 2;
    int res1 = (a && b);
    int res2 = (a || b);
    int res3 = (b && c);
    int res4 = !a;
    printf("%d %d %d %d\n", res1, res2, res3, res4);
    return 0;
}
