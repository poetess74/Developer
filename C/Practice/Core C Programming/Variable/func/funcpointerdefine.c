#include <stdio.h>

typedef struct point {
    int x, y;
} POINT;

typedef int(*FUNCPTR)(int, int);
typedef void(*PFPRINT)(const POINT*);

void print_point(const POINT *pt) {
    printf("(%d, %d)\n", pt -> x, pt -> y);
}

int get_gcd(int x, int y) {
    if (x % y == 0) {
        return y;
    }
    return get_gcd(y, x % y);
}

int add(int a, int b) {
    return a + b;
}

int main() {
    FUNCPTR pf = get_gcd;
    PFPRINT pprint = print_point;
    POINT pt = {10, 20};

    if (pf) {
        printf("GCD = %d\n", pf(10, 20));
    }
    pf = add;
    printf("10 + 20 = %d\n", (*pf)(10, 20));

    pprint(&pt);

    return 0;
}
