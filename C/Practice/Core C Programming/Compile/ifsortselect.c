#include <stdio.h>
#include <stdlib.h>
#define SORT_METHOD 1

int compare_int(const void *e1, const void *e2);
void selection_sort(int array[], int size);
void sort(int array[], int size);
void print_array(const int array[], int size);

int main() {
    int array[10] = {12, 34, 52, 5, 66, 73, 49, 86, 99, 27};

#if 0
    puts("INPUT");
    print_array(array, 10);
#endif
    sort(array, 10);
    puts("RESULT");
    print_array(array, 10);

    return 0;
}

void sort(int array[], int size) {
#if SORT_METHOD == 1
    selection_sort(array, size);
#elif SORT_METHOD == 2
    qsort(array, ARR_SIZE, sizeof(array[0]), compare_int);
#else
    //ignore
#endif
}

int compare_int(const void *e1, const void *e2) {
    const int *p1 =(const int*)e1;
    const int *p2 =(const int*)e2;
    return (*p1 - *p2);
}

void selection_sort(int array[], int size) {
    int index, temp;
    for (int i = 0; i < size - 1; i++) {
        index = i;
        for (int j = i + 1; j < size; j++) {
            if (array[index] > array[j]) {
                index = j;
            }
        }
        if (i != index) {
            temp = array[i];
            array[i] = array[index];
            array[index] = temp;
        }
    }
}

void print_array(const int array[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%2d ", array[i]);
    }
    printf("\n");
}
