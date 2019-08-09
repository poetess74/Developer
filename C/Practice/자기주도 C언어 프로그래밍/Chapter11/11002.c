#include <stdio.h>

void plus(int num) {
    printf("10큰수 : %d\n", num + 10);
}
void minus(int num) {
    printf("10작은수 : %d\n", num - 10);
}

int main() {
    int num;
    scanf("%d", &num);
    plus(num);minus(num);
    return 0;
}
