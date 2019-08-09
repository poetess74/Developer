#include <stdio.h>

int main() {
    for (int i = 7; i <= 11; i += 2) {
        for (int j = 0; j < 5 - i / 2; j++) {
            printf(" ");
        }
        for (int j = 0; j < i; j++) {
            printf("*");
        }
        printf("\n");
    }
    for (int i = 9; i >= 1; i -= 2) {
        for (int j = 0; j < 5 - i / 2; j++) {
            printf(" ");
        }
        for (int j = 0; j < i; j++) {
            printf("*");
        }
        printf("\n");
    }
    return 0;
}
