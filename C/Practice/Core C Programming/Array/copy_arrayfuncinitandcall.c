#include <stdio.h>
#define SIZE 7
void copy_array(int source[], int target[], int size);
void print_array(int array[], int size);

int main() {
    int x[SIZE] = {10, 20, 30, 40, 50};
    int y[SIZE] = {0};

    printf("x = ");
    print_array(x, SIZE);
    copy_array(x, y, 5);
    printf("y = ");
    print_array(y, SIZE);
    return 0;
}

void copy_array(int source[], int target[], int size) {
    for (int i = 0; i < size; i++) {
        target[i] = source[i];
    }
}

void print_array(int array[i], int size) {
    for (int i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}
