#include <stdio.h>

int main() {
    int val[10], temp;
    for (int i = 0; i < 10; i++) {
        scanf("%d", &val[i]);
    }
    for (int i = 0; i < 10; i++) {
        for (int j = i + 1; j < 11; j++) {
            if (val[i] < val[j]) {
                temp = val[i];
                val[i] = val[j];
                val[j] = temp;
            }
        }
    }
    for (int i = 0; i < 10; i++) {
        printf("%d ", val[i]);
    }
    printf("\n");
    return 0;
}
