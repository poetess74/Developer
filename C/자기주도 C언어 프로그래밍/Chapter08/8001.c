#include <stdio.h>

int main() {
    int num, i, sum = 0;
    scanf("%d", &num);
    for (i = 1; ; i++) {
        sum += i;
        if (sum > num) {
            break;
        }
    }
    printf("%d %d\n", i, sum);
    return 0;
}
