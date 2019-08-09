#include <stdio.h>
#include <string.h>

int main() {
    int flag = 0;
    char ch, string[20], word[10][20] = {"champion", "tel", "pencil", "jungol", "olympiad", "class", "information", "lesson", "book", "lion"};
    printf("문자를 입력하세요. ");
    scanf(" %c", &ch);
    for (int i = 0; i < 10; i++) {
        if (strchr(word[i], ch)) {
            puts(word[i]);
            flag = 1;
        }
    }
    if (flag == 0) {
        puts("찾는 단어가 없습니다. ");
    }
    flag = 0;
    printf("\n문자열을 입력하세요. ");
    scanf("%s", string);
    for (int i = 0; i < 10; i++) {
        if (strstr(word[i], string)) {
            puts(word[i]);
            flag = 1;
        }
    }
    if (flag == 0) {
        puts("찾는 단어가 없습니다. ");
    }
    return 0;
}
