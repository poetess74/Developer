#include <stdio.h>

int main() {
    int input[100], fiveTSum = 0, count = 0;
    float avg;

    for (int i = 0; i < 100; i++) {
        scanf("%d", &input[i]);
        if (input[i] == 0) {
            break;
        } else if (input[i] % 5 == 0) {
            fiveTSum += input[i];
            count++;
        }
    }

    avg = (float) fiveTSum / count;
    printf("5의 배수 : %d개\n합계 : %d\n평균 : %.1f\n", count, fiveTSum, avg);
    return 0;
}
