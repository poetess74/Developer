#include <stdio.h>
#include <string.h>

int main() {
    int length1, length2;
    char string1[50], string2[50], temp[50];
    scanf("%s %s", string1, string2);
    length1 = strlen(string1);
    length2 = strlen(string2);
    if (length1 > length2) {
        strcpy(temp, string1);
        strcpy(string1, string2);
        strcpy(string2, temp);
    }
    printf("%s\n%s\n", string1, string2);
    return 0;
}
