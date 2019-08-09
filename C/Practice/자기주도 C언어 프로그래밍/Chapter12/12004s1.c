#include <stdio.h>
#define _USE_MATH_DEFINES
#include <math.h>

int main() {
    int area;
    scanf("%d", &area);
    printf("%.2f\n", (sqrt(area / M_PI)));
    return 0;
}
