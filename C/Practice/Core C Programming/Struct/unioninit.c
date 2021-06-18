#include <stdio.h>

union test {
    int i;
    char c;
    short s;
};

int main() {
    union test t1 = {0x12345678};
    printf("union size : %d\n", sizeof(union test));

    printf("t1.i loc : %p\n", &t1.i);
    printf("t1.c loc : %p\n", &t1.c);
    printf("t1.s loc : %p\n", &t1.s);

    printf("t1.i = %x\n", t1.i);
    printf("t1.c = %x\n", t1.c);
    printf("t1.s = %x\n", t1.s);

    return 0;
}
