#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main() {
    int inputA, inputB;
    float inputC, inputD;
    scanf("%d %d", &inputA, &inputB);
    scanf("%f %f", &inputC, &inputD);
    if (abs(inputA) > abs(inputB)) {
        printf("%d\n", inputA);
    } else {
        printf("%d\n", inputB);
    }
    if (fabs(inputC) < fabs(inputD)) {
        printf("%.2f\n", inputC);
    } else {
        printf("%.2f\n", inputD);
    }
    return 0;
}

