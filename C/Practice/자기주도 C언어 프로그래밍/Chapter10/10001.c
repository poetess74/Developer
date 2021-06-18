#include <stdio.h>

int main() {
    int input, count[11] = {0};

    while (1) {
        scanf("%d", &input);
        if (input < 1 || input > 10) {
            break;
        }
        count[input]++;
    }
    for (int i = 1; i <= 10; i++) {
        if (count[i] > 0) {
            printf("%d : %d개\n", i, count[i]);
        }
    }
    return 0;
}
