#include <stdio.h>

int main() {
    int a[5];
    int *p = a;

    for (int i = 0; i < 5; i++) {
        scanf("%d", &*(p + i));
    }
    for (int i = 0; i < 5; i += 2) {
        printf("%d ", *(p + i));
    }
    printf("\n");

    return 0;
}
