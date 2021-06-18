#include <stdio.h>

typedef struct point {
    int x, y;
} POINT;

#define DEF_RANGE_OF(rtype)\
    typedef struct range_of_##rtype {\
        rtype start;\
        rtype end;\
    } RANGE_OF_##rtype;

DEF_RANGE_OF(int)
DEF_RANGE_OF(double)
DEF_RANGE_OF(POINT)

#define IN_RANGE(value, range) \
    (((value) >= (range.start)) && ((value) <= (range.end)))

int main() {
    RANGE_OF_int hour_range = {0, 23};
    RANGE_OF_int minute_range= {0, 59};
    int hour, minute;

    while (1) {
        printf("INPUT HOUR: ");
        scanf("%d", &hour);
        if (IN_RANGE(hour, hour_range)) {
            break;
        }
        printf("WRONG FORMAT\n");
    }
    while (1) {
        printf("INPUT MIN: ");
        scanf("%d", &minute);
        if (IN_RANGE(minute, minute_range)) {
            break;
        }
        printf("WRONG FORMAT\n");
    }
    printf("INSERTED TIME IS %d:%d\n", hour, minute);

    return 0;
}
