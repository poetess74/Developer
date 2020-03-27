#include <stdio.h>

int main() {
    int a, b, c;
    scanf("%d %d %d", &a, &b, &c);
    int resultA = (a==b);
    int resultB = (b==c);
    int resultC = (a!=b);
    int resultD = (b!=c);
    printf("%d %d %d %d \n", resultA, resultB, resultC, resultD);
    return 0;
}
