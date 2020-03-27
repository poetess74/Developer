//Unstable
#include <stdio.h>
#include <string.h>

int main() {
    int inputA, inputB, inputC, inputD, inputE;
    char string[50];
    scanf("%d %d %d %d %d", &inputA, &inputB,  &inputC,  &inputD,  &inputE);
    sprintf(string, "%d %d %d %d %d", inputA, inputB, inputC, inputD, inputE);
    int length = strlen(string);
    for (int i = 0; i < length; i++) {
        if(string[i]  == ' ') {
            printf("%c\n", string[i + 1]);
        } else {
            printf("%c\n", string[i]);
        }
    }
    return 0;
}
