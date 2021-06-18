#include <stdio.h>

int main() {
    int num, count = 0;
    for (int i = 1; i <=10; i++) {
        scanf("%d", &num);
        if (num % 2 == 0) {
            count++;
        }
    }
    printf("입력받은 짝수는 %d개입니다.\n", count);
    return 0;
}
