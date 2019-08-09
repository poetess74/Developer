#include <stdio.h>

int main() {
    int input, sum = 0;
    scanf("%d", &input);
    for (int i = 1; i <= input; i++) {
        if (i % 5 == 0) {
            sum += i;
        }
    }
    printf("%d\n", sum);
    return 0;
}
