#include <stdio.h>
#define one 1
#define two 2
#define three 3

int main() {
    for (int i = one; i <= three; i++) {
        for (int j = one; j <= three; j++) {
            printf("%d + %d = %d\n", i, j, i + j);
        }
    }
    return 0;
}
