#include <stdio.h>

int main() {
    int input, even = 0, odd = 0;
    for (int i = 1; i <= 10; i++) {
        scanf("%d", &input);
        if (input % 2 == 0) {
            even++;
        } else if (input % 2 != 0) {
            odd++;
        }
    }
    printf("짝수 : %d개\n홀수 : %d개\n", even, odd);
    return 0;
}
