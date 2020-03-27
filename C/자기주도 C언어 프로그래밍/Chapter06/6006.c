#include <stdio.h>

int main() {
    int input;
    while (input != 4) {
        printf("\t1. 입력하기\n");
        printf("\t2. 출력하기\n");
        printf("\t3. 삭제하기\n");
        printf("\t4. 끝내기\n");
        printf("작업할 번호를 선택하세요. ");
        scanf("%d", &input);
        switch (input) {
            case 1:
                printf("입력하기를 선택하셨습니다.\n");
                break;
            case 2:
                printf("출력하기를 선택하셨습니다.\n");
                break;
            case 3:
                printf("삭제하기를 선택하셨습니다.\n");
                break;
            case 4:
                printf("끝내기를 선택하셨습니다.\n");
                break;
            default:
                printf("잘못 선택하셨습니다.\n");
                break;
        }
    }
}
