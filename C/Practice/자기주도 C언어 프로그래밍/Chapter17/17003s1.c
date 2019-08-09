#include <stdio.h>
#include <stdlib.h>

int main() {
    int* p1 = (int*) malloc(sizeof(int));
    int* p2 = (int*) malloc(sizeof(int));
    scanf("%d %d", p1, p2);
    printf("%d + %d = %d\n", *p1, *p2, *p1 + *p2);
    printf("%d - %d = %d\n", *p1, *p2, *p1 - *p2);
    printf("%d * %d = %d\n", *p1, *p2, *p1 * *p2);
    printf("%d / %d = %d\n", *p1, *p2, *p1 / *p2);
    free(p1);
    free(p2);
    return 0;
}
