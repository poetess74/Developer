#include <stdio.h>

int main() {
    int w, h;
    scanf("%d %d", &w, &h);
    w += 5; h *= 2;
    printf("가로 : %d\n세로 : %d\n넓이 : %d\n", w, h, w * h);
    return 0;
}
