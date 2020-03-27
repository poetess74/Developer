//Unstable
#include <stdio.h>
#include <string.h>

int main() {
    char ch, word[10][20]; 
    for (int i = 0; i < 10; i++) {
        scanf("%s", word[i]);
    }
    scanf(" %c", &ch);
    for (int i = 0; i < 10; i++) {
        if (word[i][strlen(word[i])] == ch) {
            puts(word[i]);
        }
    }
    return 0;
}
