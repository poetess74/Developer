#include <stdio.h>

int main() {
    int a = 10, b = 20;
    const int *p1 = &a;
    int *const p2 = &a;
    const int * const p3 = &a;

    printf("*p1 = %d\n", *p1);
//  *p1 = 100; //Compile ERR
    p1 = &b;
    printf("*p1 = %d\n", *p1);

//  p2 = &b;   //Compile ERR
    *p2 = 100;
    printf("*p2 = %d\n", *p2);
    
//  *p3 = 100; //Compile ERR
//  p3 = &b;   //Compile ERR
    printf("*p3 = %d\n", *p3);
    return 0;
}
