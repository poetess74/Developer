#include <stdio.h>
#include <string.h>

int main() {
    int length;
    char inputA[50], inputB[50];
    scanf("%s %s", inputA, inputB);
    length = strlen(inputA) + strlen(inputB);
    printf("%d\n", length);
    return 0;
}
