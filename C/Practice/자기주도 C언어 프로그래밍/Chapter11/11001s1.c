#include <stdio.h>

void string() {
    printf("~!@#$%^&*()_+|\n");
}

int main() {
    int input;
    scanf("%d", &input);
    for (int i = 0; i < input; i++) {
        string();
    }
    return 0;
}
