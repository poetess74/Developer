#include <stdio.h>

int main() {
    int mh, mw, gh, gw;
    printf("민수의 키와 몸무게 입력 ");
    scanf("%d %d", &mh, &mw);
    printf("기영이의 키와 몸무게 입력 ");
    scanf("%d %d", &gh, &gw);
    int res = (mh > gh && mw > gw);
    printf("%d\n", res);
    return 0;
}
