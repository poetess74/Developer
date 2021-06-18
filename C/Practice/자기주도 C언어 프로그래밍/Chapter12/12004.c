#include <stdio.h>
#include <math.h>

int main() {
    float area, rad, exp;
    printf("정사각형의 넓이 : ");
    scanf("%f", &area);
    printf("정사각형의 한 변의 길이 : %1f\n", sqrt(area));
    printf("밑과 지수 : ");
    scanf("%f %f", &rad, &exp);
    printf("%f의 %f승은 %f입니다. \n", rad, exp, pow(rad, exp));
    return 0;
}
