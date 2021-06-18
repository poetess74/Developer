#include <stdio.h>
#include <stdlib.h>
#include <time.h>

typedef struct point {
    int x, y;
} POINT;

void print_point(const POINT *pt);
void set_point(POINT *pt, int x, int y);

int main() {
    POINT array[5] = {0};
    int sz = sizeof(array) / sizeof(array[0]);
    srand((unsigned int) time(NULL));
    for (int i = 0; i < sz; i++) {
        int x = rand() % 100;
        int y = rand() % 100;
        set_point(&array[i], x, y);
    }
    for (int i = 0; i < sz; i++) {
        print_point(&array[i]);
        printf(" ");
    }
    printf("\n");

    return 0;
}

void print_point(const POINT *pt) {
    printf("(%d, %d)", pt -> x, pt -> y);
}

void set_point(POINT *pt, int x, int y) {
    pt -> x = x;
    pt -> y = y;
}
