#include <stdio.h>

int main() {
    int a[3] = {10, 20, 30};
    int *p = a;
    printf("a = %p, p = %p\n", a, p);
    printf("%d %d %d\n", a[0], a[1], a[2]);
    printf("%d %d %d\n", a[0], a[1], a[2]);
    printf("%d %d %d\n", *a, *(a + 1), *(a + 2));
    printf("%d %d %d\n", *p, *(p + 1), *(p + 2));
    return 0;
}
