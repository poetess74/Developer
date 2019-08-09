#include <stdio.h>

int main() {
    int input[100], count;
    for (int i = 0; i < 100; i++) {
        scanf("%d", &input[i]);
        if (input[i] == 0) {
            break;
        }
        count = i;
    }
    for (int i = 1; i < count; i += 2) {
        printf("%d ", input[i]);
    }
    printf("\n");
    return 0;
}
