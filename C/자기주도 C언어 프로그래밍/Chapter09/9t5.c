#include <stdio.h>

int main() {
    float weight[6];
    float sum = 0;

    for (int i = 0; i < 6; i++) {
        scanf("%f", &weight[i]);
        sum += weight[i];
    }

    printf("%.1f\n", sum / 6);
}
