#include <stdio.h>
#define ARR_SIZE 5

int add(int a, int b) {
    return a + b;
}

int main() {
    int array[ARRAY_SIZE] = {0};
    array[0] = 5;
    array[1] = array[0] + 10;
    array[2] = add(array[0], array[1]);
    printf("input int 2 : ");
    scanf("%d %d", &array[3], &array[4]);
    for (i = 0; i < ARR_SIZE; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
    return 0;
}
