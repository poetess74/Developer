#include <stdio.h>
#include <limits.h>

int main() {
    int num[10];
    int min = INT_MAX;
    for (int i = 0; i < 10; i++) {
        scanf("%d", &num[i]);
    }
    for (int i = 0; i < 10; i++) {
        if (min > num[i]) {
            min = num[i];
        }
    }
    printf("%d\n", min);
    return 0;
}
