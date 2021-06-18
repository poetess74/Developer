#include <stdio.h>
#include <string.h>

int main() {
    int length, x = 0, y = 0;
    char st[50], word[25][50];
    gets(st);
    length = strlen(st);
    for (int i = 0; i < length; i++) {
        if (st[i] == ' ') {
            word[x][y] = '\0';
            x++;
            y = 0;
        } else {
            word[x][y] = st[i];
            y++;
        }
    }
    word[x][y] = '\0';
    x++;
    for (int i = 0; i < x; i++) {
        puts(word[i]);
    }
    return 0;
}
