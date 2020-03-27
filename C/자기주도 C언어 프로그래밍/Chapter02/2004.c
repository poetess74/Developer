#include <stdio.h>

int main() {
    int rad = 5;
    float pi = 3.141592f;

    printf("원주 : %d * 2 * %f = %f\n", rad, pi, rad * 2 * pi);
    printf("넓이 : %d * %d * %f = %f\n", rad, rad, pi, rad * rad * pi);
    return 0;
}
