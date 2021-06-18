#include <stdio.h>
#include <ctype.h>

int main() {
    char ch;
    while (1) {
        ch = getchar();
        if (isupper(ch)) {
            printf("대문자입니다.\n");
        } else if (islower(ch)) {
            printf("소문자입니다.\n");
        } else if (isdigit(ch)) {
            printf("숫자입니다.\n");
        } else {
            printf("영문, 숫자 이외의 문자입니다.\n");
            break;
        }
        getchar();
    }
    return 0;
}
