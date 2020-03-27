#include <stdio.h>

int main() {
    int a[5];
    int *p = a;

    scanf("%d %d %d %d %d", &*p, &*(p + 1), &*(p + 2), &*(p + 3), &*(p + 4));
    printf("%d %d %d\n", *p, *(p + 2), *(p + 4));
    return 0;
}
