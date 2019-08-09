#include <stdio.h>

int main() {
    int input[100], count = 0;
    for (int i = 0; i < 100; i++) {
        scanf("%d", &input[i]);
        if (input[i] == -1) {
            break;
        }
        count++;
    }
    for (int i = count - 1; i > count - 4 ; i--) {
        printf("%d ", input[i]);
    }
    printf("\n");
    return 0;
}
