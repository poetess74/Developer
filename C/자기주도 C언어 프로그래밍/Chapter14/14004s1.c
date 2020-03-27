#include <stdio.h>
#include <string.h>

int main() {
    int length, limit; char string[50];
    scanf("%s %d", string, &limit);
    length = strlen(string);
    for (int i = length - 1; i >= limit - 1; i--) {
        printf("%c", string[i]);
    }
    printf("\n");
    return 0;
}
