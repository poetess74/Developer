#include <stdio.h>
#include <string.h>

int main() {
    int length; char string[50];
    scanf("%s", string);
    length = strlen(string);
    printf("입력받은 문자열의 길이는 %d입니다. \n", length);
    for (int i = length - 1; i >= 0; i--) {
        printf("%c", string[i]);
    }
    printf("\n");
    return 0;
}
