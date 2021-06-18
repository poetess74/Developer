#include <stdio.h>

int main() {
    int val[10];
    for (int i = 0; i < 10; i++) {
        val[i] = i + 1;
    }
    for (int i = 0; i < 10; i++) {
        printf("%d ", val[i]);
    }
    printf("\n");
    return 0;
}
