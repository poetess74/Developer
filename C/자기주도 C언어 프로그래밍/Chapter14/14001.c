#include <stdio.h>

int main() {
    char ch;
    while (1) {
        scanf(" %c", &ch);
        printf("%c -> %d\n", ch, ch);
        if (ch == '0') {
            break;
        }
    }
    return 0;
}
