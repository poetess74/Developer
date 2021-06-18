//Unstable
#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main() {
    int length;
    char string[100];
    scanf("%s", string);
    length = strlen(string);
    for (int i = 0; i < length; i++) {
        if (isalpha(string[i])) {
            if (islower(string[i])) {
                string[i] = toupper(string[i]);
                printf("%s", &string[i]);
            } else if (isupper(string[i])) {
                printf("%s", &string[i]);
            }
        } else {
            continue;
        }
    }
    printf("\n");
    return 0;
}
