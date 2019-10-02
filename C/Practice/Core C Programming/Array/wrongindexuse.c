#include <stdio.h>

int main() {
    int array[5] = {10, 20, 30, 40, 50};
    printf("array = ");
    for (int i = 0; i < 5; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
    printf("arr[5] = %d\n", array[5]);
//  array[5] = 100;
    return 0;
}
