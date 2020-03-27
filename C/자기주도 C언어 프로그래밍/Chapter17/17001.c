#include <stdio.h>

int main() {
    int a = 10;
    int *p;
    p = &a;

    printf("a = %d, &a = %p\n", a, &a);
    printf("*p = %d, p = %p\n", *p, p);
    return 0;
}
