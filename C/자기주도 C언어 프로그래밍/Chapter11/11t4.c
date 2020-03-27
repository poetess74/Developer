#include <stdio.h>

int doubleVal(int inputA, int inputB) {
    if (inputA < inputB) {
        int temp = inputA;
        inputA = inputB;
        inputB = temp;
    }
    return inputA * inputA - inputB * inputB;
}

int main() {
    int inputA, inputB;
    scanf("%d %d", &inputA, &inputB);
    printf("%d\n", doubleVal(inputA, inputB));
    return 0;
}
