#include <stdio.h>
#define _USE_MATH_DEFINES
#include <math.h>

int main() {
    float r, ci;
    scanf("%f", &r);
    ci = r * 2 * M_PI;
    printf("%.2f\n", ci);
    return 0;
}
