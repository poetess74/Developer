#include <stdio.h>

int main() {
    int input, cnt = 0;
    while (input != 0) {
        scanf("%d", &input);
        if (input % 3 != 0 && input % 5 != 0) {
            cnt++;
        }
    }
    printf("%d", cnt);
    printf("\n");
    return 0;
}
