#include <stdio.h>

int main() {
    int a;
    int *p = &a;

    scanf("%d", &a);
    printf("a = %d, *p = %d\n", a, *p);
    scanf("%d", p);
    printf("a = %d, *p = %d\n", a, *p);
    a = a + 5;
    printf("a = %d, *p = %d\n", a, *p);
    *p = *p * 2;
    printf("a = %d, *p = %d\n", a, *p);
    (*p)--;
    printf("a = %d, *p = %d\n", a, *p);
    return 0;
}
