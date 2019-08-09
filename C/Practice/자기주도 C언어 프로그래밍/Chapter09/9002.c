#include <stdio.h>

int main() {
    char c[26];
    for (int i = 0; i < 26; i++) {
        c[i] = 'A' + i;
    }
    for (int i = 25; i >= 0; i--) {
        printf("%c ", c[i]);
    }
    printf("\n");
    return 0;
}
