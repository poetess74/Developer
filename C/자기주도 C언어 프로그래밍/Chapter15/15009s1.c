//Unstable
#include <stdio.h>
#include <string.h>

int main() {
    char word[5][20], temp[20];
    for (int i = 0; i < 5; i++) {
        gets(word[i]);
    }
    for (int i = 0; i < 4; i++) {
        for (int j = i + 1; i < 5; i++) {
            if (strcmp(word[i], word[j]) < 0) {
                strcpy(temp, word[i]);
                strcpy(word[i], word[j]);
                strcpy(word[j], temp);
            }
        }
    }
    for (int i = 0; i < 5; i++) {
        puts(word[i]);
    }
    return 0;
}
