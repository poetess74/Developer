#include <stdio.h>

int main() {
    int num, sum = 0, cnt = 0, avg;
    do {
        scanf("%d", &num);
        if (num % 2 == 1) {
            sum += num;
            cnt++;
        }
    } while (num != 0);
    avg = sum / cnt;
    printf("홀수의 합 = %d\n", sum);
    printf("홀수의 평균 = %d\n", avg);
    return 0;
}
