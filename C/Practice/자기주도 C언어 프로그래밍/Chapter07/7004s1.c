#include <stdio.h>

int main() {
    int input, sum = 0;
    scanf("%d", &input);
    for (int i = input; i <= 100; i++) {
        sum += i;
    }
    printf("%d\n", sum);
    return 0;
}
