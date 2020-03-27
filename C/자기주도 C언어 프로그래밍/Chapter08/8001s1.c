#include <stdio.h>

int main() {
    int num, i, sum = 0;

    scanf("%d", &num);
    for (i = 1; ; i += 2) {
        if (sum > num - 2) {
            i -= 2;
            break;
        } else {
            sum += i;
        }
    }
    printf("%d %d\n", i, sum);
    return 0;
}
