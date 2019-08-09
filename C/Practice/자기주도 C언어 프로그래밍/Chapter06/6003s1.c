#include <stdio.h>

int main() {
    int input, loop = 0;
    while (1) {
        printf("정수를 입력하세요. ");
        scanf("%d", &input);
        if (input > 0) {
            printf("양수입니다. \n");
            continue;
        } else if (input < 0) {
            printf("음수입니다. \n");
            continue;
        } else {
            break;
        }
    }
}
