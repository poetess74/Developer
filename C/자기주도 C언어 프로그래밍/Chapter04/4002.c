// 이것은 한줄을 처리하는 주석입니다. 
// 주석처리 하고자 하는 줄마다 "//" 표시를 해 주어야 합니다. 

#include <stdio.h>

int main() {
    int a; //정수형 변수를 선언한다. 
    scanf("%d", &a); //정수를 입력 받는다. 
    printf("%d / 4 = %d\n", a, a / 4);
    printf("%d / 4.0 = %.2f\n", a, a / 4.0);
    return 0;
}
