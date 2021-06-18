#include <stdio.h>

int main() {
    int no;
    printf("1. 개\n2. 고양이\n3. 병아리\n");
    printf("영어로 알고 싶은 번호를 입력하세요. ");
    scanf("%d", &no);
    switch (no) {
        case 1:
            printf("dog\n");
            break;
        case 2:
            printf("cat\n");
            break;
        case 3:
            printf("chick\n");
            break;
        default:
            printf("I don't know\n");
            break;
    }
    return 0;
}
