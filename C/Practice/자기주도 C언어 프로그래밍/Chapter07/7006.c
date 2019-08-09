#include <stdio.h>

int main() {
    int score, sum = 0; float avg;
    for (int i = 1; i <= 5; i++) {
        scanf("%d", &score);
        sum += score;
    }
    avg = (float)sum / 5;
    printf("총점 : %d\n", sum);
    printf("평균 : %.1f\n", avg);
    return 0;
}
