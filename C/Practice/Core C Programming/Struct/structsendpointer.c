#include <stdio.h>

typedef struct point {
    int x, y;
} POINT;

void print_point(POINT *pt);

int main() {
    POINT array[] = {
        {0, 0}, {10, 10}, {20, 20}, {30, 30}, {40, 40},
    };
    int sz = sizeof(array) / sizeof(array[0]);

    for (int i = 0; i < sz; i++) {
        print_point(&array[i]);
        printf(" ");
    }
    printf("\n");

    return 0;
}

void print_point(POINT *pt) {
    printf("(%d, %d)", pt -> x, pt -> y);
}
