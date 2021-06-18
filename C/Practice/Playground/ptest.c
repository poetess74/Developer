#include <stdio.h>

int main()
{
    int a = 20;
    int b = 30;

    const int * const_int_pointer = &a;
    int * const int_const_pointer = &a;

    const_int_pointer = &b;
    int_const_pointer = &b;

    *const_int_pointer = 30;
    *int_const_pointer = 30;

    return 0;
}
