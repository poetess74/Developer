#include <stdio.h>
#include <ctype.h>

int main () {
    char ch;
    while (1) {
        ch = getchar();
        if (isalpha(ch)) {
            printf("%c\n", ch); 
        } else if (isdigit(ch)) {
            printf("%d\n", ch);
        } else {
            break;
        }
        getchar();
    }
    return 0;
}
