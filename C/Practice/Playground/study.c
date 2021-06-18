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
    char s1[10];
    char s2[10];
    char s3[3];
    char s4[] = "xyx";
    char s5[4];
//  ---------------------------------------------------    
    strcpy(s1, "abc");
//  strcpy("apple", s2);    // const src string
//  strcpy("hello", "bye"); // const src string
//  strcpy(s3, "good job"); // too long src string to dest array
    strcpy(s5, s4);
//  ---------------------------------------------------    
    char str[20] = "abc";
    strcpy(str, "def");
    strcat(str, "xyz");
    printf("%s\n", str);
//  ---------------------------------------------------    
    const char *p2 = "BTS";
    printf("%p\n", p2);
    printf("%c\n", *p2);
    printf("%s\n", p2);
    printf("%c\n", p2[1]);
//  ---------------------------------------------------    
//  char* p3 = "fake love"; // bus error
    char songA[] = "anpanman";
    char *p4 = songA;
//  char *p5 = "mic drop"; // bus error
    char songB[] = "dna";
    const char *p6 = "tear";
    const char *favorite = "dna";
//  p3[0] = 'F';
    p4[0] = 'A';
//  strcat(p5, " remix");
    if (strcmp(songB, "DNA") == 0) {
        printf("same song");
    }
    int len1 = strlen(p6);
    favorite = "best of me";
//  ---------------------------------------------------    
    printf("*****\n");
    char *bts[] = { "Jin", "Jungkook", "Suga", "RM", "J-Hope", "Jimin", "V" };
    printf("%s\n", *bts);
    printf("%d\n", sizeof(bts));
    printf("%d\n", sizeof(bts[0]));
//  ---------------------------------------------------    
    return 0;
}
