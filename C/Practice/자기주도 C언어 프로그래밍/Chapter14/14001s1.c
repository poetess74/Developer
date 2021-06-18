#include <stdio.h>

int main() {
    int ch;
    while (1) {
        printf("아스키 코드 =? ");
        scanf("%d", &ch);
        if (ch < 33 || ch > 127) {
            break;
        }
        printf("%c\n", ch);
    }
    return 0;
}
