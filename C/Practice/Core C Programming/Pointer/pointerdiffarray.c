#include <stdio.h>

int main() {
    int x[5] = {1, 2, 3, 4, 5};
    int y[5];
    int *p = x;

    for (int i = 0; i < 5; i++) {
        printf("%d ", p[i]);
    }
    printf("\n");

    p = y;

    for (int i = 0; i < 5; i++) {
        p[i] = x[i];
    }

    for (int i = 0; i < 5; i++, p++) {
        printf("%d ", *p);
    }
    printf("\n");
    return 0;
}
