#include <stdio.h>

int main() {
    int num[5];
    char str[13] = "Hong Gil Dong";
    for (int i = 0; i < 4; i++) {
        scanf("%d", &num[i]);
    }
    for (int i = 0; i < 4; i++) {
        printf("%c", str[num[i]]);
    }
    printf("\n");
    return 0;
}
