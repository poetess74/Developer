#include <stdio.h>

int main() {
    int input, cal = 0;
    scanf("%d", &input);
    for (int i = 1; i <= 11; i++) {
        if (i == 1) {
            printf("");
        } else {
            printf("%d ", cal);
        }
        cal = input * i;
    }
    printf("\n");
    return 0;
}
