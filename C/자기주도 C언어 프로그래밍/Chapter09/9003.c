#include <stdio.h>

int main() {
    int num[10];
    for (int i = 0; i < 10; i++) {
        scanf("%d", &num[i]);
    }
    printf("%d %d %d\n", num[2], num[4], num[9]);
    return 0;
}
