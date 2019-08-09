#include <stdio.h>
#include <string.h>

int main() {
    float a, b, c;
    char string[200];
    scanf("%f %f %f", &a, &b, &c);
    sprintf(string, "%.2f%.2f%.2f", a, b, c);
    int length = strlen(string);
    for (int i = 0; i < length; i++) {
        if (string[i] == '.') {
            printf("\n");
        } else {
            printf("%c", string[i]);
        }
    }
    printf("\n");
    return 0;
}
