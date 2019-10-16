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
    printf("%d", a);
    printf("%p", p);
    printf("%p", constp);
    printf("%p", intconstp);
    printf("%p", constintconst);
    *p = b;
//    *constp = b;          // read-only variable is not assignable
//    intconstp = &b;       // cannot assign to variable 'intconstp' with const-qualified type 'int *const'
//    *constintconst = b;   // read-only variable is not assignable
    return 0;
}
