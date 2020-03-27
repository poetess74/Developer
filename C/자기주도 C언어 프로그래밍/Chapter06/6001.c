#include <stdio.h>

int main() {
    char Char = 'A';

    while (Char <= 'Z') {
        printf("%c", Char ++);
    }
    printf("\n");
    return 0;
}
