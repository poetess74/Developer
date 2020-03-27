#include <stdio.h>
#define _USE_MATH_DEFINES
#include <math.h>

void area(float r) {
    float _area;
    _area = r * r * M_PI;
    printf("%.2f\n", _area);
}

int main() {
    int r;
    scanf("%d", &r);
    area(r);
    return 0;
}
