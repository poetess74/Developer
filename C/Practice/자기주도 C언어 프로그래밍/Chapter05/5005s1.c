#include <stdio.h>

int main() {
    float a, b;
    scanf("%f %f", &a, &b);
    if (a >= 4.0f && b >= 4.0f) {
        printf("A\n");
    } else if (a >= 3.0f && b >= 3.0f) {
        printf("B\n");
    } else {
        printf("C\n");
    }
}
