#include <stdio.h>
#include <string.h>

int main() {
    int length, count = 0; char string[100];
    gets(string);
    length = strlen(string);
    for (int i = 0; i < length; i++) {
        if (string[i] == ' ') {
            count++;
        }
    }
    printf("%d\n", count + 1);
    return 0;
}
