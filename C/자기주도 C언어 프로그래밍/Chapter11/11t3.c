#include <stdio.h>

void metrix(int val) {
    int times = 1;
    for (int i = 1; i <= val; i++) {
        for (int j = 1; j <= val; j++) {
            printf("%d ", j * times);
        }
        times++;
        printf("\n");
    }
}

int main() {
    int input;
    scanf("%d", &input);
    metrix(input);
    return 0;
}
