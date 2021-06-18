#include <stdio.h>

int main() {
    int input, odd = 0, even = 0;
    while (input != 0) {
        scanf("%d", &input);
        if (input % 2 == 0) {
            even++;
        } else {
            odd++;
        }
    }
    printf("홀수 : %d개\n짝수 : %d개\n", odd, even - 1);
    return 0;
}
