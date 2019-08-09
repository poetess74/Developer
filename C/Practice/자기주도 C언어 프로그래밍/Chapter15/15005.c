#include <stdio.h>
#include <string.h>

int main() {
    char string1[50], string2[50], string3[50];
    scanf("%s %s", string1, string2);
    strcpy(string3, string2);
    strcat(string3, string1);
    puts(string3);
    return 0;
}
