#include <stdio.h>
#include <string.h>

int main() {
    int length; char string[100];
    gets(string);
    length = strlen(string);
    for (int i = 0; i < length; i++) {
        if (string[i] == ' ') {
            printf("\n");
        } else {
            printf("%c", string[i]);
        }
    }
    printf("\n");
    return 0;
}
