#include <stdio.h>

void relay(int input) {
    int num = 0;
    for (int i = 1; i <= input; i++) {
        num = num + i;
    }
    printf("%d\n", num);
}

int main() {
    int input;
    scanf("%d", &input);
    relay(input);
    return 0;
}
