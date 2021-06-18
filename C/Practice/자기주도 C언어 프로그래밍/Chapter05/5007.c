#include <stdio.h>

int main() {
    int num;
    printf("1. 삽입\n");
    printf("2. 수정\n");
    printf("3. 삭제\n");
    printf("숫자를 선택하세요. ");
    scanf("%d", &num);
    switch (num) {
        case 1:
            printf("삽입을 선택하셨습니다. \n");
            break;
        case 2:
            printf("수정을 선택하셨습니다. \n");
            break;
        case 3:
            printf("삭제를 선택하셨습니다. \n");
            break;
        default:
            printf("잘못 입력하셨습니다. \n");
    }
    return 0;
}
