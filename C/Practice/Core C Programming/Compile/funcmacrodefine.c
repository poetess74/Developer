#include <stdio.h>
#define SQUARE(x) ((x) * (x))

int square(int x) {
    return x * x;
}

int main() {
    int a = 5;
    printf("SQUARE(10) = %d\n", SQUARE(10));
    printf("SQUARE(1.5) = %f\n", SQUARE(1.5));
    printf("SQUARE(\'a\') = %d\n", SQUARE('a'));
//  printf("SQUARE(\"a\") = %d\n", SQUARE("a"));

    printf("square(1 + 2) = %d\n", square(1 + 2));
    printf("SQUARE(1 + 2) = %d\n", SQUARE(1 + 2));

    printf("square(++a) = %d\n", square(++a));

    a = 5;
    printf("SQUARE(++a) = %d\n", SQUARE(++a));

    printf("square(3.1) = %d\n", square(3.1));
    printf("SQUARE(3.1) = %d\n", SQUARE(3.1));

    return 0;
}
