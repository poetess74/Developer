#include <stdio.h>

void name(int input) {
    if (input < 1) {
       return;
    }
    name (input - 1);
    printf("재귀함수\n");
}

int main() {
    int num;
    scanf("%d", &num);
    if (num < 21 && 0 < num) {
        name(num);
    }
    return 0;
}
