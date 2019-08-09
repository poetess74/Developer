#include <stdio.h>

void test1 (int x) {
    x = 20;
}

void test2 (int *p) {
    *p = 20;
}

int main() {
    int x = 10;
    test1(x);
    printf("test1 result : %d\n", x);
    test2(&x);
    printf("test2 result : %d\n", x);

    return 0;
}
