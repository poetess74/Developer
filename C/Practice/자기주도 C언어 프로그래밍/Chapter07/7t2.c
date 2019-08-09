#include <stdio.h>

int main() {
    int num1, num2;
    scanf("%d %d", &num1, &num2);
    if (num1 > num2) {
        for (int i = num2; i <= num1; i++) {
            printf("%d ", i);
        }
    } else {
        for (int i = num1; i <= num2; i++) {
            printf("%d ", i);
        }
    }
    printf("\n");
    return 0;
}
