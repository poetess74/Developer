#include <stdio.h>

int main() {
    int inputA, inputB, inputC;
    int resultA, resultB, resultC;

    scanf("%d %d %d", &inputA, &inputB, &inputC);

    if (inputA > inputB) {
        if (inputA > inputC) {
            resultA = inputA;
        } else {
            resultA = inputC;
        }
    } else {
        if (inputB > inputC) {
            resultA = inputB;
        } else {
            resultA = inputC;
        }
    }

    if (inputA < inputB) {
        if (inputA < inputC) {
            resultC = inputA;
        } else {
            resultC = inputC;
        }
    } else {
        if (inputB < inputC) {
            resultC = inputB;
        } else {
            resultC = inputC;
        }
    }

    resultB = (inputA + inputB + inputC) - resultA - resultC;
    printf("max : %d, mid : %d, min : %d\n", resultA, resultB, resultC);

    return 0;
}
