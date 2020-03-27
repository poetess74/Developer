#include <stdio.h>

int main() {
    float c = 21.6f, f = 110.3f;

    printf("섭씨 %.1f도는 화씨 %.1f도이다.\n", c, c * 1.8 + 32);
    printf("화씨 %.1f도는 섭씨 %.1f도이다.\n", f, (f - 32) * 0.55f);
    return 0;
}
