#include <stdio.h>

typedef struct point {
    int x, y;
} POINT;

#define PRINT_POINT(pt) {\
    printf(#pt " = ");\
    printf("(%d, %d)\n", pt.x, pt.y);\
}

int main() {
    int a = 123;
    POINT pt1 = {10, 20};
    POINT pt2 = {5, 10};
    POINT array[] = {{1, 1}, {2, 2}, {3, 3}};
    PRINT_POINT(pt1);
    PRINT_POINT(pt2);

    for (int i = 0; i < 3; i++) {
        PRINT_POINT(array[i]);
    }
    return 0;
}
