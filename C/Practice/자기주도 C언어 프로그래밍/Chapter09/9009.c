#include <stdio.h>

int main() {
    int num[5] = {95, 75, 85, 100, 50};
    int temp;
    for (int i = 0; i < 4; i++) {
        for (int j = i + 1; j < 5; j++) {
            if (num[i] > num[j]) {
                temp = num[i];
                num[i] = num[j];
                num[j] = temp;
            }
        }
    }
    for (int i = 0; i < 5; i++) {
        printf("%d ", num[i]);
    }
    printf("\n");
    return 0;
}
