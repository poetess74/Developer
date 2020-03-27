#include <stdio.h>

int main() { 
    double score;
    while (true) {
        double temp;
        score = 0;
        printf("성적 입력: ");
        scanf("%lf", &score);
//        temp = int(score);
        if (score == 0) {
            printf("성취도 : F\n");
        } else if (0.1 <= score && score <= 20) {
            printf("성취도 : E\n");
        } else if (20.1 <= score && score <= 40.1) {
            printf("성취도 : D\n");
        } else if (40.2 <= score && score <= 60.2) {
            printf("성취도 : C\n");
        } else if (60.3 <= score && score <= 80.3) {
            printf("성취도 : B\n");
        } else if (80.4 <= score && score <= 100.0) {
            printf("성취도 : A\n");
        } else {
            printf("성취도 : 올바르지 않은 성적. 다시 입력\n");
        }
    }
}
