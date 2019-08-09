#include <stdio.h>

int main() {
    float f; double d;
    printf("두 개의 실수를 입력하세요.\n");
    scanf("%f\n%lf", &f, &d);
    printf("f = %.2f\n", f);
    printf("d = %.2lf\n", d);
    return 0;
}
