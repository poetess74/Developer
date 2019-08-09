#include <stdio.h>

// 오류: auto와 register는 스토리지 클래스가 아님
// auto void autoFunc()
// {
//     printf("auto 내부 함수 호출됨.\n");
// }
// register void registerFunc()
// {
//     printf("register 내부 함수 호출됨.\n");
// }

void staticValueTest()
{
    static int staticValue = 7;
    staticValue++;
    printf("%d ", staticValue);
}

static void staticFunc()
{
    printf("static 내부 함수 호출됨.\n");
}

// 외부 파일에 선언된 함수 prototype 선언 (extern 생략)
void externFuncOtherFile(void);

int main(int argc, const char * argv[])
{
    // 새로운 블록시작
    {
        int defaultValue = 5;
        auto int autoValue = 10;
        register int registerValue = 3;
        // 레지스터 포인터 사용 x
        // int *ptr = &registerValue;
        printf("result : %d\n",
                defaultValue + autoValue - registerValue);
    }
    // 오류: 선언 x
    // printf("result : %d\n",
    //         defaultValue + autoValue - registerValue);
    
    printf("static value result : ");
    for (int i = 0; i < 5; i++)
    {
        staticValueTest();
    }
    printf("\n");
    
    // 외부 파일 참조 x
    // printf("static value result : ", staticValue);

    staticFunc();

    // 외부 파일 참조 x
    // staticFuncOtherFile();
    
    extern int externValue;
    printf("extern value result : %d\n", externValue);
    externFuncOtherFile();
    
    return 0;
}
