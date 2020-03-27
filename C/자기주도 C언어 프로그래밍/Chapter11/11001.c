#include <stdio.h>

void line() {
    puts("========================================");
}
int main() {
    line();
    puts("line 함수를 호출하였습니다.\n");
    puts("line 함수를 호출하였습니다.\n");
    line();
    return 0;
}
