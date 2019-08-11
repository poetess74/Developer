#include <stdio.h>

int main() {
    int *pi;
    double *pd;
    char *pc;
    
    printf("size of (pi) = %zd\n", sizeof(pi));
    printf("size of (pd) = %zd\n", sizeof(pd));
    printf("size of (pc) = %zd\n", sizeof(pc));

    printf("size of (int*) = %zd\n", sizeof(int*));
    printf("size of (double*) = %zd\n", sizeof(double*));
    printf("size of (char*) = %zd\n", sizeof(char*));

    return 0;
}
