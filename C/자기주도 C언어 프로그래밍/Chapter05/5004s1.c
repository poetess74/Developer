#include <stdio.h>

int main() {
    float pound;
    scanf("%f", &pound);
    if (pound > 88.45f) {
        printf("헤비급\n");
    } else if (pound > 72.57f) {
        printf("크루저급\n");
    } else if (pound > 61.23f) {
        printf("미들급\n");
    } else if (pound > 50.8f) {
        printf("라이트급\n");
    } else {
        printf("플라이급\n");
    }
}
