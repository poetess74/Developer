#include <stdio.h>

void times(int valA, int valB) {
    for (int i = valA; i <= valB; i++) {
        printf("== %d단 ==\n", i);
        for (int j = 1; j <= 9; j++) {
            printf("%d * %d = %d\n", i, j, i * j);
        }
        printf("\n");
    }
}

int main() {
    int inputA, inputB;
    scanf("%d %d", &inputA, &inputB);
    times(inputA, inputB);
    return 0;
}
