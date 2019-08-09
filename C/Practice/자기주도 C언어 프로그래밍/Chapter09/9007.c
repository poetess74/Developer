#include <stdio.h>
#include <limits.h>

int main() {
    int num[10];
    int max = INT_MIN, min = INT_MAX;

    for (int i = 0; i < 10; i++) {
        scanf("%d", &num[i]);
    }
    for (int i = 0; i < 10; i++) {
        if (num[i] % 2 == 0) {
            if (max < num[i]) {
                max = num[i];
            }
        } else {
            if (min > num[i]) {
                min = num[i];
            }
        }
    }
    printf("%d %d\n", min, max);
    return 0;
}
