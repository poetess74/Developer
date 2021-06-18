#include <stdio.h>

int main() {
    int input[100], count, i;
    for (i = 0; i < 100; i++) {
        scanf("%d", &input[i]);
        if (input[i] == 0) {
            i--;
            break;
        }
    }
    count = i;
    for (i = count; i >= 0; i--) {
        printf("%d ", input[i]);
    }
    printf("\n");
    return 0;
}
