#include <stdio.h>

void num(int input) {
    printf("%d ", input);
    if (input <= 1) {
        return;
    }
    num(input - 1);
}

int main() {
    int input;
    scanf("%d", &input);
    num(input);
    printf("\n");
    return 0;
}
