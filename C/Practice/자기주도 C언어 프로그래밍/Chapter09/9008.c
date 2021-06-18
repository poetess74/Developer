#include <stdio.h>

int main() {
    int score[10];
    int sum = 0;
    float avg;
    
    for (int i = 0; i < 10; i++) {
        scanf("%d", &score[i]);
    }
    for (int i = 0; i < 10; i++) {
        sum += score[i];
    }
    avg = sum / 10.0f;
    printf("총점 = %d\n", sum);
    printf("평균 = %.1f\n", avg);
    return 0;
}
