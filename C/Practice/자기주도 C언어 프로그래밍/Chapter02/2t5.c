#include <stdio.h>

int main() {
    float yard, cm = 91.44f;
    printf("몇 야드인지 입력하시오. ");
    scanf("%f", &yard);
    printf("%.1f야드 = %.1fcm\n", yard, yard * cm);
    return 0;
}
