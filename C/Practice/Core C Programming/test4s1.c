#include <stdio.h>

int main() {
    int x = 0, y = 0;
    scanf("%d %d", &x, &y);

    printf("+%d = %d\n", x, +x);
    printf("-%d = %d\n", y, -y);
    return 0;
}
