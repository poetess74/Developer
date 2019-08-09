#include <stdio.h>
#include <time.h>

int main() {
    int a = 0;
    time_t now;
    struct tm tt;
    time(&now);
    tt = *localtime(&now);
    printf("Debug 4t4.c LN 10:5 : %d\n", a);
    a = tt.tm_year;
    printf("Debug 4t4.c LN 12:5 : %d\n", a);
    a += tt.tm_mon;
    printf("Debug 4t4.c LN 14:5 : %d\n", a);
    a += tt.tm_mday;
    printf("Debug 4t4.c LN 16:5 : %d\n", a);
    printf("%d %d %d\n", 1, 2, 3);
    return 0;
}
