#include <stdio.h>

int sum_Times(int input) {
    if (input <= 0) {
        return 0;
    }
    return input + sum_Times(input - 1);
}

int main() {
    int input;
    scanf("%d", &input);
    printf("%d\n", sum_Times(input));
    return 0;
}
