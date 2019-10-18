//
//  main.c
//  Cprograming
//
//  Created by KimHyeongmin on 2014. 2. 21..
//  Copyright (c) 2014년 KimHyeongmin. All rights reserved.
//

#include <stdio.h>

int main(){
    int a = 10;
    int b = 20;
    int *p = &a;
    const int *constp;
    int * const intconstp = &a;
    const int * const constintconst = &a;
    scanf("%d", &a);
    printf("%d\n", a);
    printf("%p\n", p);
    printf("%p\n", &p);
    printf("%p\n", constp);
    printf("%p\n", intconstp);
    printf("%p\n", constintconst);
    *p = b;
//    *constp = b;          // read-only variable is not assignable
//    intconstp = &b;       // cannot assign to variable 'intconstp' with const-qualified type 'int *const'
//    *constintconst = b;   // read-only variable is not assignable
    return 0;
}
