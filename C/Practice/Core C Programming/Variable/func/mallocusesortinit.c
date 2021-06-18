#include <stdio.h>
#include <stdlib.h>

void print_array(const int array[], int size);
int compare_int(const void *e1,const void *e2);

int main() {
    int size;
    int *array = NULL;

    printf("INPUT COUNT : ");
    scanf("%d", &size);
    array = (int*) malloc(sizeof(int) *size);
    if (array == NULL) {
        printf("Fail to init memory\n");
        return -1;
    }
    printf("INPUT NUM : ");
    for (int i = 0; i < size; i++) {
        scanf("%d", &array[i]);
    }
    puts("--- BEFORE ---");
    print_array(array, size);
    qsort(array, size, sizeof(array[0]), compare_int);
    puts("--- RESULT ---");
    print_array(array, size);

    free(array);
    array = NULL;
    return 0;
}

void print_array(const int array[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}

int compare_int(const void *e1,const void *e2) {
    const int *p1 = (const int *) e1;
    const int *p2 = (const int *) e2;
    return (*p1 - *p2);
}
