#include <stdio.h>

int main() {
    int count, input, sum = 0; float avg;
    scanf("%d", &count);
    for (int i = 1; i <= count; i++) {
        scanf("%d", &input);
        sum += input;
    }
    avg = (float)sum / count;
    printf("%.2f\n", avg);
    return 0;
}
