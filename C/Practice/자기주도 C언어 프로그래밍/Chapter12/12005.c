#include <stdio.h>
#define _USE_MATH_DEFINES
#include <math.h>

int main() {
    float radius, area;
    printf("원의 반지름 : ");
    scanf("%f", &radius);
    area = pow(radius, 2) * M_PI;
    printf("원의 넓이\n");
    printf("버림 : %.0f\n", floor(area));
    printf("반올림 : %.0f\n", round(area));
    printf("올림 : %.0f\n", ceil(area));
    return 0;
}
