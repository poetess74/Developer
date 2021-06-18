#include <stdio.h>

int main() {
    int a;
    scanf("%d", &a);
    printf("후치 %d\n전치 %d\n", a++, ++a);
    return 0;
}
