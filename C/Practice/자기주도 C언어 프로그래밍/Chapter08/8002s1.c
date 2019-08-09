#include <stdio.h>

int main() {
    int input;
    scanf("%d", &input);
    for (int i = 1; i <= input; i++) {
        for (int j = input; j >= i; j--) {
            printf("*");
        }
        if (i < input) {
            printf("\n");
        }
    }
    for (int i = 0; i <= input; i++) {
        for (int j = 0; j < i; j++) {
            printf("*");
        }
        printf("\n");
    }
    return 0;
}
