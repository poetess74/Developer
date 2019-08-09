#include <stdio.h>

int main() {
    int input, score, sum = 0;
    float avg;
    scanf("%d", &input);
    for (int i = 1; i <= input; i++) {
        scanf("%d", &score);
        sum += score;
    }
    avg = (float)sum / input;
    if (avg >= 80) {
        printf("평균 : %.1f\n합격\n", avg);
    } else {
        printf("평균 : %.1f\n불합격\n", avg);
    }
    return 0;
}
