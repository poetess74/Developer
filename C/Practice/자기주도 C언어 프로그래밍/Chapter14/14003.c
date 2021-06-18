#include <stdio.h>

int main() {
    int num[5];
    char str[50] = "jungol olympiad";
    for (int i = 0; i < 5; i++) {
        scanf("%d", &num[i]);
    }
    for (int i = 0; i < 5; i++) {
        printf("%c", str[num[i]]);
    }
    printf("\n");
    return 0;
}
