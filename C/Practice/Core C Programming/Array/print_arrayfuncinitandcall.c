#include <stdio.h>
#define MAX 10
void print_array(int array[], int size);

int main() {
    int scores[] = {99, 98, 67, 72, 90, 82};
    int size = sizeof(scores) / sizeof(scores[0]);
    int array[MAX] = {0};

    print_array(scores, size);
    print_array(array, MAX);
    return 0;
}

void print_array(int array[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}

