#include <stdio.h>
#include <string.h>

int main() {
    char string1[50], string2[50];
    scanf("%s %s", string1, string2);
    strncat(string2, string1, 3);
    strncpy(string1, string2, 3);
    puts(string1);
    puts(string2);
    return 0;
}
