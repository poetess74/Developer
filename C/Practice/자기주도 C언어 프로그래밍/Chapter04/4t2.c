// Unstable
#include <stdio.h>

int main() {
    float a, b, c;
    scanf("%f %f %f", &a, &b, &c);
    printf("총점 %d점\n평균 %d점\n", (int)(a + b + c), (int)(a + b + c) / 3);
    return 0;
}
