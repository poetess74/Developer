//Unstable
#include <stdio.h>

int main() {
    int num[10];
    int even = 0, odd = 0, count = 0;
    float avg;
    
    for (int i = 0; i < 10; i++) {
        scanf("%d", &num[i]);
        if (num[i] % 2 == 0) {
            even += num[i];
        } else {
            odd += num[i];
            count++;
        }
    }
    avg = (float) odd / count;
    printf("짝수번째 합 : %d\n홀수번째 평균 : %.1f\n", even, avg);
    return 0;
}
