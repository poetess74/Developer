#include <stdio.h>

int main() {
    int input[100], sum = 0, count = 0;
    for (int i = 0; i < 100; i++) {
        scanf("%d", &input[i]);
        if(input[i] == 0) {
            break;
        }
        count++;
    }

    printf("%d개\n", count);
    for (int i = 0; i < count; i++) {
        if (input[i] % 2 == 0) {
            printf("%d ", input[i] / 2);
        } else {
            printf("%d ", input[i] * 2);
        }
    }
    printf("\n");
    return 0;
}
