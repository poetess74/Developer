#include <stdio.h>
#define SIZE 5

int main() {
    int data[SIZE] = {7, 3, 9, 5, 1};
    int index, temp;
    for (int i = 0; i < SIZE; i++) {
        index = i;
        for (int j = i + 1; j < SIZE; j++) {
            if (data[index] > data[j]) {
                index = j;
            }
        }
        if (i != index) {
            temp = data[i];
            data[i] = data[index];
            data[index] = temp;
        }
    }
    printf("result : ");
    for (int i = 0; i < SIZE; i++) {
        printf("%d ", data[i]);
    }
    printf("\n");
    return 0;
}
