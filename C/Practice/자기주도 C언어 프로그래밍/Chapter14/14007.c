#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main() {
    int length;
    char string[100];
    scanf("%s", string);
    length = strlen(string);
    for (int i = 0; i < length; i++) {
        if (isupper(string[i])) {
            string[i] = tolower(string[i]);
        } else if (islower(string[i])) {
            string[i] = toupper(string[i]);
        }
    }
    printf("%s\n", string);
    return 0;
}
