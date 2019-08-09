#include <stdio.h>
#include <stdlib.h>

int main() {
    int num, i;
    float sum = 0; 
    scanf("%d", &num);
    float *p = (float*)calloc(num, sizeof(int));
    for (i = 0; i < num; i++) {
        scanf("%f", &p[i]);
        sum += p[i];
    }
    for (i = 0; i < num; i++) {
        printf("%.2f ", p[i]);
    }
    printf("\n합계 : %.2f\n평균 : %.2f\n", sum, sum / num);
    return 0;
}
