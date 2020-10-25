#include <stdio.h>

static int staticValue = 5;

static void staticFuncOtherFile()
{
    printf("staticValue : %d\n", staticValue);
    printf("static 외부 함수 호출됨.\n");
}

int externValue = 5;

// extern은 생략 가능
extern void externFuncOtherFile()
{
    printf("extern 외부 함수 호출됨.\n");
}
