#include <stdio.h>

int main() {
//  int *p1 = 0x12345678;          //Compile ERR
    int *p2 = (int*)0x12345678;    //Runtime ERR
    
    int a = 10;
    int *p3 = &a;
    int *p4 = 0;
    int *p5 = NULL;

    printf("p2 = %p\n", p2);
    printf("p3 = %p\n", p3);
    printf("p4 = %p\n", p4);
    printf("p5 = %p\n", p5);

    return 0;
}
