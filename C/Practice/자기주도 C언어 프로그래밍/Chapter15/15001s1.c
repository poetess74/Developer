#include <stdio.h>

int main() {
    char string[5][20];
    for (int i = 0; i < 5; i++) {
        scanf("%s", string[i]);
    }
    for (int i = 4; i >= 0; i--) {
        printf("%s\n", string[i]);
    }
    return 0;
}
