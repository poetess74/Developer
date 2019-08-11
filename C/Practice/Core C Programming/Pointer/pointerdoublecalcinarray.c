#include <stdio.h>

int main() {
    int array[5] = { 1, 2, 3, 4, 5};
    int *p = &array[0];

    for (int i = 0; i < 5; i++, p++) {
        printf("p = %p, ", p);
        printf("*p = %d\n", *p);
    }

    return 0;
}
