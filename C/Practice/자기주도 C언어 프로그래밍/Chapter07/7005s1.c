#include <stdio.h>

int main() {
    int num, count3x = 0, count5x = 0;
    for (int i = 1; i <=10; i++) {
        scanf("%d", &num);
        if (num % 3 == 0) {
            count3x++;
        }
        if (num % 5 == 0) {
            count5x++;
        }
    }
    printf("3의 배수 : %d개\n5의 배수 : %d개\n", count3x, count5x);
    return 0;
}
