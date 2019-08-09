#include <stdio.h>

int main() {
    int input[10], even = 0, odd = 0;
    for (int i = 0; i < 10; i++) {
        scanf("%d", &input[i]);
    }
    for (int i = 0; i < 10; i++) {
        if (i % 2 == 0) {
            even += input[i];
        } else {
            odd += input[i];
        }
    }
    printf("홀수 번째 합 : %d\n짝수 번째 합 : %d\n", even, odd);
    return 0;
}
