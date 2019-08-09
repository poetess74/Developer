#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main() {
    int inputA, inputB;
    float inputC, inputD;

    scanf("%d %d", &inputA, &inputB);
    scanf("%f %f", &inputC, &inputD);
    printf("두 정수의 차 : %d\n", abs(inputA-inputB));
    printf("두 실수의 차 : %f\n", fabs(inputC-inputD));
    return 0;
}
