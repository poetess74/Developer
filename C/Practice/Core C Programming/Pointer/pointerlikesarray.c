#include <stdio.h>

int main() {
    int array[5] = {1, 2, 3, 4, 5};
    int *p = array;

    for (int i = 0; i < 5; i++) {
        printf("p[%d] = %d\n", i, p[i]);
    }

    return 0;
}
