#include <stdio.h>

int main() {
    float num[5];
    float *p = num;
    for (int i = 0; i < 5; i++) {
        scanf("%f", &p[i]);
    }
    for (int i = 0; i < 5; i++) {
        printf("%.1f ", p[i]);
    }

    printf("\n");
    return 0;
}
