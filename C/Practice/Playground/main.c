//
//  main.c
//  C programing
//
//  Created by HyeongminKim on 2014. 2. 21.
//  Copyright (c) 2014년 HyeongminKim. All rights reserved.
//

#include <stdio.h>

int main(){
    int a = 10;
    int b = 20;
    int *p = &a;
    const int *constp = (int*)0xffffff; // macOs default var init value is 0 (0x0)
    int * const intconstp = &a;
    const int * const constintconst = &a;
    printf("input : ");
    scanf("%d", &a);
    printf("a = %d\n", a);
    printf("p = %p\n", p);
    printf("&p = %p\n", &p);
    printf("constp = %p\n", constp);
    printf("intconstp = %p\n", intconstp);
    printf("constintconst = %p\n", constintconst);
    *p = b;
//    *constp = b;          // read-only variable is not assignable
//    intconstp = &b;       // cannot assign to variable 'intconstp' with const-qualified type 'int *const'
//    *constintconst = b;   // read-only variable is not assignable
    return 0;
}
