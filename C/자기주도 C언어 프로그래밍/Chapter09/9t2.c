#include <stdio.h>

int main() {
    int input[5];
    for (int i = 0; i < 5; i++) {
        scanf("%d", &input[i]);
    }
    printf("%d\n", input[0] + input[2] + input[4]);
    return 0;
}
