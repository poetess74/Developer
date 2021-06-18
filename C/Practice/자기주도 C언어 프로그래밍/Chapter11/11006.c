#include <stdio.h>

int calc(int x, int y, char simbol) {
    switch (simbol) {
        case '+':
            return x + y;
        case '-':
            return x - y;
        case '*':
            return x * y;
        case '/':
            return x / y;
    }
    return 0;
}

int main() {
    int a, b; char c;
    scanf("%d %c %d", &a, &c, &b);
    printf("%d %c %d = %d\n", a, c, b, calc(a, b, c));
    return 0;
}
