#include <stdio.h>
#define ABS(x) (((x) > 0) ? (x) : (-(x)))
#define MAX(x, y) (((x) > (y)) ? (x) : (y))
#define MIN(x, y) (((x) < (y)) ? (x) : (y))
#define PRINT_POINT(pt_name, pt) { \
    printf(pt_name " = "); \
    printf("(%d, %d)\n", pt.x, pt.y); \
}
#define ARR_SIZE(array) (sizeof(array) / sizeof(array[0]))

typedef struct point {
    int x, y;
} POINT;

int main() {
    POINT pt1 = {100, 200};
    POINT pt2 = {5, 3};
    int data[] = {1, 2, 3, 4, 5, 6};
    printf("ABS(-5) = %d\n", ABS(-5));
    printf("MAX(10, 20) = %d\n", MAX(10, 20));
    printf("MIN(10, 20) = %d\n", MIN(10, 20));
    PRINT_POINT("pt1", pt1);
    PRINT_POINT("pt2", pt2);

    for (int i = 0; i < ARR_SIZE(data); i++) {
        printf("%d ", data[i]);
    }
    printf("\n");
    return 0;
}
