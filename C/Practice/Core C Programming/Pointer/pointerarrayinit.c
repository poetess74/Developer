#include <stdio.h>

int main() {
    int a, b, c, d, e;
    int *array[5] = {&a, &b, &c, &d, &e};

    for (int i = 0; i < 5; i++) {
        *array[i] = i;
        printf("%d ", *array[i]);
    }
    printf("\n");

    return 0;
}
