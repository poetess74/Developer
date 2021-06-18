#include <stdio.h>
#include <limits.h>

int main() {
    int num[10];
    int max = INT_MIN;
    for (int i = 0; i < 10; i++) {
        scanf("%d", &num[i]);
    }
    for (int i = 0; i < 10; i++) {
        if (max < num[i]) {
            max = num[i];
        }
    }
    printf("%d\n", max);
    return 0;
}
