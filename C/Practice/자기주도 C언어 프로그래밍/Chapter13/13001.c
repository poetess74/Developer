#include <stdio.h>

void name(int input) {
    if (input < 1) {
       return;
    }
    name (input - 1);
    printf("홍길동\n");
}

int main() {
    name(10);
    return 0;
}
