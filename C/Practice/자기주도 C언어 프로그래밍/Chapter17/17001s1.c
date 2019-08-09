#include <stdio.h>

int main() {
    int num;
    int *point;
    point = &num;

    scanf("%d", &num);
    point = &num;

    printf("%p %d\n", point, num);
}
