//Unstable
#include <stdio.h>
#include <string.h>

int main() {
    int length; char word[50], temp;
    scanf("%s", word);
    length = strlen(word);
    for (int i = 0; i < length; i++) {
        temp = word[0];
        for (int j = 0; j < length - 1; j++) {
            word[j] = word[j + 1];
        }
        word[length - 1] = temp;
        printf("%s\n", word);
    }
    return 0;
}
