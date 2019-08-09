#include <stdio.h>

int main() {
    int input;
    scanf("%d", &input);
    for (int i = 1; i <= input; i++) {
        for (int j = input - 1; j >= input - i; j--) {
            printf("*");
        }
        printf("\n");
    }
    return 0;
}
