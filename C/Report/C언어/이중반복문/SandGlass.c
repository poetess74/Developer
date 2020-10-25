#include <stdio.h>

int main() {
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < i; j++) {
            printf(" ");
        } 
        for (int k = 0; k < 2 * (5 - i) - 1; k++) {
            printf("*");
        }
        printf("\n");
    }
    for (int i = 1; i <= 5; i++) {
        for (int j = 0; j < 5 - i; j++) {
            printf(" ");
        } 
        for (int k = 1; k < 2 * i; k++) {
            printf("*");
        }
       printf("\n");
    }
    return 0;
}
