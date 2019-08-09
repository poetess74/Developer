#include <stdio.h>

int main() {
    int len, i;
    char string[50];
    for (i = 0; i < 50; i++) {
        scanf("%c", &string[i]);
        if (string[i] == 10) {
            break;
        }
    }
    len = i;
    for (i = 0; i < len; i++) {
        printf("%c", string[i]);
    }
    printf("\n");
    return 0;
}
