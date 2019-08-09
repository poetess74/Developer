#include <stdio.h>

int main() {
    int num, sum = 0, cnt = 0; float avg;
    while (1) {
        scanf("%d", &num);
        sum += num;
        cnt++;
        if (num >= 100) {
            break;
        }
    }
    avg = (float)sum / cnt;
    printf("%d\n%.1f\n", sum, avg);
    return 0;
}
