//Unstable
#include <stdio.h>

int main() {
    int input[10], min = 100, max = 100, flag = 0;

    for (int i = 0; i < 10; i++) {
        scanf("%d", &input[i]);
    }
    for (int i = 0; i < 10; i++) {
        if (input[i] < max || min <= input[i]) {
            if (max > input[i]) {
                max = input[i];
            }
            if (min <= input[i]) {
                min = input[i];
            }
            flag = 1;
        }
    }
    printf("%d %d\n", min, max);
    return 0;
}
