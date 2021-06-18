#include <stdio.h>

void num(int input) {
    if (input <= 0) {
        return;
    }
    num(input - 1);
    printf("%d ", input);
}

int main() {
    int _num;
    scanf("%d", &_num);
    num(_num);
    printf("\n");
    return 0;
}
