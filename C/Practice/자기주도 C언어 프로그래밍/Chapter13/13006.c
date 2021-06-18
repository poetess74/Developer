#include <stdio.h>

void revert(int inputA, int inputB) {
    if (inputA <= 0) {
        printf("%d\n", inputB);
    } else {
        revert(inputA / 10, inputB * 10 + inputA % 10);
    }
}

int main() {
    int num;
    scanf("%d", &num);
    revert(num, 0);
    return 0;
}
