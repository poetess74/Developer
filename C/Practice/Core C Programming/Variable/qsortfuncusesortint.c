#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define ARR_SIZE 10

int compare_int (const void *e1, const void *e2);
void print_array (const int array[], int size);

int main() {
    int array[ARR_SIZE] = {0};
    srand((unsigned int) time(NULL));

    for (int i = 0; i < ARR_SIZE; i++) {
        array[i] = rand() % 100;
    }
    puts("--- INPUT ---\n");
    print_array(array, ARR_SIZE);
    
    qsort(array, ARR_SIZE, sizeof(array[0]), compare_int);

    puts("--- RESULT ---\n");
    print_array(array, ARR_SIZE);

    return 0;
}

int compare_int (const void *e1, const void *e2) {
    const int *p1 = (const int*) e1;
    const int *p2 = (const int*) e2;
    return (*p1 - *p2);
}

void print_array (const int array[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}
