#include <stdio.h>
#include <string.h>

int main() {
    char string1[50], string2[50];
    scanf("%s %s", string1, string2);
    strncpy(string2, string1, 2);
    strncat(string2, string1, 2);
    puts(string2);
    return 0;
}
