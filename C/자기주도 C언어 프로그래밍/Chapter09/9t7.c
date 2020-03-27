#include <stdio.h>
#include <limits.h>

int main() {
    int input[100], G = INT_MIN, L = INT_MAX, count = 1;
    for (int i = 0; i < 100; i++) {
        scanf("%d", &input[i]);
        if (input[i] == 999) {
            break;
        }
        count++;
    }
    for (int i = 0; i < count - 1; i++) {
        if (G < input[i]) {
            G = input[i];
        } else if (input[i] < L) {
            L = input [i];
        }
    }
    printf("최대값 : %d\n최소값 : %d\n", G, L);
    return 0;
}
