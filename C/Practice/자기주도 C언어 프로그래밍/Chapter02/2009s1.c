#include <stdio.h>

int main() {
    float f1, f2; double d;
    scanf("%f\n%f\n%lf", &f1, &f2, &d);
    printf("%.3f\n", f1);
    printf("%.3f\n", f2);
    printf("%.3lf\n", d);
    return 0;
}
