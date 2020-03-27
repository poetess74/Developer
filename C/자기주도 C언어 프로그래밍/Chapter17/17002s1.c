#include <stdio.h>

int main() {
    int *p;
    scanf("%d", p);
    printf("%d...%d\n", *p / 10, *p % 10);
    return 0;
}
