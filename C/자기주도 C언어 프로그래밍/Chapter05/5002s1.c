#include <stdio.h>

int main() {
    int w, h, c;
    scanf("%d %d", &h, &w);
    c = w + 100 - h;
    if (c > 0) {
        printf("당신은 비만이군요.\n비만수치는 %d입니다. \n", c);
    }
    return 0;
}
