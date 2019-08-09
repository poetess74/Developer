#include <stdio.h>

int main() {
    int a = 0, b = 1, c = 2;
    int res1 = (a < b) && (b < c);
    int res2 = (a && b) || (b && c);
    int res3 = (a || !c);
    int res4 = (a != b) && (b != c);
    printf("%d %d %d %d\n", res1, res2, res3, res4);
    return 0;
}
