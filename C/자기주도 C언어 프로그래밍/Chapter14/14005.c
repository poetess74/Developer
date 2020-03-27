#include <stdio.h>
#include <string.h>

int main() {
    int lenght;
    char string[50] = "우리나라 대한민국!";
    lenght = strlen(string);
    printf("%s \n", string);
    printf("위 문자열의 길이는 %d입니다.\n", lenght);
    return 0;
}
