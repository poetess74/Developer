#include <stdio.h>

typedef struct date {
    unsigned short year:7;
    unsigned short month:4;
    unsigned short day:5;
//  unsigned short the_day_of_week:3;
} DATE;

int main() {
    DATE dday;
    dday.year = 18;
    dday.month = 11;
    dday.day = 30;

    printf("DATE size = %d\n", sizeof(DATE));
    printf("%d.%d.%d\n", dday.month, dday.day, dday.year+2000);

    return 0;
}
