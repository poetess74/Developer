#include <stdio.h>

int main() {
    char input[10];
    for (int i = 0; i < 10; i++) {
        scanf(" %c", &input[i]);
    }
    for (int i = 0; i < 10; i++) {
        printf("%c", input[i]);
    }
    printf("\n");
    return 0;
}
