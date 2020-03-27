//Unstable
#include <stdio.h>

int main() {
    int num;
    do {
        scanf("%d", &num);
        if (num % 3 == 0) {
            printf("%d\n", num / 3);
        }
    } while (num != 0 || num != -1);
}
