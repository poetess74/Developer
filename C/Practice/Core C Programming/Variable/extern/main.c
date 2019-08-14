#include <stdio.h>

void test_global();

extern int global;

int main() {
    test_global();
    printf("global = %d\n", global);

    return 0;
}
