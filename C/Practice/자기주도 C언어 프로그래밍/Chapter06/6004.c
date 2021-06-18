#include <stdio.h>

int main() {
    int num, sum = 0, cnt = 0; float avg;
    
    while (1) {
        scanf("%d", &num);
        if (num == 0) {
            break;
        }
        sum += num;
        cnt++;
    }
    avg = (float)sum / cnt;
    printf("입력된 자료의 개수 = %d\n", cnt);
    printf("입력된 자료의 합개 = %d\n", sum);
    printf("입력된 자료의 평균 = %.2f\n", avg);
    return 0;
}
