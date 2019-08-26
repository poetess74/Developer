#include <stdio.h>
#define DEBUG
#define USE_RECURSION

int get_factorial(int num);

int main() {
    for (int i = 0; i < 6; i++) {
        printf("%2d! = %7d\n", i, get_factorial(i));
    }
    return 0;
}

#ifdef USE_RECURSION
int get_factorial(int num) {
#ifdef DEBUG
    printf("get_factorial(%d) is called...\n", num);
#endif
    if (num <= 1) {
        return 1;
    }
    return num * get_factorial(num - 1);
}
#else
int get_factorial(int num) {
    int result = 1;
#ifdef DEBUG
    printf("get_factorial(%d) is called...\n");
#endif
    for (int i = 1; i <= num; i++) {
        result *= i;
    }
    return result;
}
#endif
