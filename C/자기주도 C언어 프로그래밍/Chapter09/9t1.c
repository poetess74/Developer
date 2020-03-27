#include <stdio.h>

int main() {
    int input[10];
    for (int i = 0; i < 10; i++) {
        scanf(" %c", &input[i]);
    }
    for (int i = 9; i >= 0; i--) {
        printf("%c ", input[i]);
    }
    printf("\n");
    return 0;
}
