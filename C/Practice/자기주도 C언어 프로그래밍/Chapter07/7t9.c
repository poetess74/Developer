#include <stdio.h>

int main() {
    int input;
    scanf("%d", &input);
    for (int i = 1; i <= input; i++) {
        for (int j = 1; j <= input; j++) {
            printf("(%d, %d) ", i, j);
        }
        printf("\n");
    }
    return 0;
}
