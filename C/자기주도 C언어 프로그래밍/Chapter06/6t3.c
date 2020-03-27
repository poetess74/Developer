//Unstable
#include <stdio.h>

int main() {
    int score, sum = 0, cnt = 0;
    float avg = 0;
    do {
        scanf("%d", &score);
        if (0 <= score && score <= 100) {
            sum += score;
            cnt++;
        }
    } while (0 <= score && score <= 100);
    avg = sum / cnt;
    printf("합계 : %d점\n평균 : %.1f점\n", sum, avg);
    return 0;
}
