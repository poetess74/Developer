#include <stdio.h>

int main() {
    char c[10];
    for(int i = 0; i < 10; i++) {
        scanf(" %c", &c[i]);
    }
    printf("%c %c %c\n", c[0], c[3], c[6]);
    return 0;
}
