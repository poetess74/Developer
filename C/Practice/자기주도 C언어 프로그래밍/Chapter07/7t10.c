#include <stdio.h>

int main() {
    int input1, input2;
    scanf("%d %d", &input1, &input2);
    for (int i = 1; i < 10; i++) {
        for (int j = 5; j >= 3; j--) {
            printf("%d * %d = %d\t", j, i, j * i);
        }
        printf("\n");
    }
    return 0;
}
