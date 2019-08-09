//Unstable
#include <stdio.h>

int main() {
    int inputS, inputL, count = 1, sum = 0;
    float avg;

    scanf("%d %d", &inputS, &inputL);
    if (inputS > inputL) {
        int temp = inputS;inputS = inputL;inputL = temp;
        for (int result = 3; result <= inputL; result *= 3) {
            sum += result;
            count++;
        }
    } else {
        for (int result = 5; result <= inputL; result *= 5) {
            sum += result;
            count++;
        }
    }
    avg = sum / count;
    printf("합계 : %d\n평균 : %.1f\n", sum, avg);
    return 0;
}
