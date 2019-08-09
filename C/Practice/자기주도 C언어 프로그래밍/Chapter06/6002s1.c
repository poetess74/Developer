#include <stdio.h>

int main () {
    int loop = 1, num, sum = 0;
    scanf("%d", &num);
    while (loop <= num) {
        sum = sum + loop;
        loop ++;
    }
    printf("%d\n", sum);
    return 0;
}
