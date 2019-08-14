#include <stdio.h>

void test_static() {
    int local = 0;
    static int s_local = 0;

    printf("local = %d, ", local++);
    printf("s_local = %d\n", s_local++);
}

int main() {
    for (int i = 0; i < 5; i++) {
        test_static();
    }

    return 0;
}
