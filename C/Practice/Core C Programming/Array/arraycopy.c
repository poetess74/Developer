#include <stdio.h>

int main() {
    int x[5] = {10, 20, 30, 40, 50};
    int y[5] = {0};
    for (i = 0; i < 5; i++) {
        y[i] = x[i];
    }
//  y = x;
    printf("y = ");
    for (i = 0; i < 5; i++) {
        printf("%d ", y[i]);
    }
    printf("\n");
    return 0;
}
