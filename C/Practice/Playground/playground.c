//
//  main.c
//  C programing
//
//  Created by HyeongminKim on 2014. 2. 21.
//  Copyright (c) 2014년 HyeongminKim. All rights reserved.
//

#include <stdio.h>
#include <string.h>

int main(){
    int *pi = NULL; double *pd = NULL; 
    char *pc = NULL; float *pf = NULL;
    printf("sizeof(pi) = %zd\n", sizeof(pi));
    printf("sizeof(pd) = %zd\n", sizeof(pd));
    printf("sizeof(pc) = %zd\n", sizeof(pc));
    printf("sizeof(pf) = %zd\n", sizeof(pf));
    puts("--------------------------------");
// --------------------------------------------------
    int a = 10; int b = 20; int *p1 = &a;
    const int *constp = (int*)0xffffff; // macOs init variable is 0x0
    int * const intconstp = &a;
    const int * const constintconst = &a;
//  *constp = b;          // read-only variable
//  intconstp = &b;       // const-qualified type variable
//  *constintconst = b;   // read-only variable
    printf("a = %d\n", a);
    printf("p = %d\n", *p1);
    *p1 = b;              // equal a = 20
    printf("a = %d\n", a);
    printf("p = %d\n", *p1);
    puts("--------------------------------");
    printf("&p = %p\n", &p1);
    printf("constp = %p\n", constp);
    printf("intconstp = %p\n", intconstp);
    printf("constintconst = %p\n", constintconst);
    puts("--------------------------------");
//  ---------------------------------------------------    
    return 0;
}
