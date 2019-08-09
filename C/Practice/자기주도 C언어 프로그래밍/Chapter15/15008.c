#include <stdio.h>
#include <string.h>

int main() {
    int comp; char string1[20], string2[20];
    scanf("%s %s", string1, string2);
    comp = strcmp(string1, string2);
    if (comp == 0) {
        puts("두 문자열은 같습니다. \n");
    } else if (comp > 0) {
        printf("%s 이(가) 더 큽니다.\n", string1);
    } else {
        printf("%s 이(가) 더 큽니다. \n", string2);
    }

    if (strncmp(string1, string2, 3) == 0) {
        puts("앞의 세 문자가 같습니다. ");
    } else {
        puts("앞의 세 문자가 같지 않습니다. ");
    }
    return 0;
}
