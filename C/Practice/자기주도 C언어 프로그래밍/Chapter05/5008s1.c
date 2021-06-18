#include <stdio.h>

int main() {
    float avg;
    scanf("%f", &avg);
    switch ((int)avg) {
        case 4:
            printf("장학금을 받아가세요\n");
            break;
        case 3:
            printf("다음 학기를 준비하세요\n");
            break;
        case 2:
            printf("계절 학기에 등록하세요\n");
            break;
        default:
            printf("다음 학기에 재수강하세요\n");
            break;
    }
    return 0;
}
