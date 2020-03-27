//Unstable
#include <stdio.h>

int func_month(int input_M, int input_Y) {
    if (input_M < 1 || input_M > 12) {
        return 0;
    } else {
        if (func_year(input_Y)) {
            return 1;
        } else {
            return 0;
        }
    }
}

int func_day(int input_M, int input_D, int input_Y) {
    if (input_D > 31 || input_D < 1) {
        return 0;
    } else {
        if (func_month(input_M, input_Y)) {
            return 1;
        } else {
            return 0;
        }
    }
}

int func_year(int input_Y) {
    if ((input_Y % 4 == 0 && input_Y % 100 != 0) || input_Y % 400 == 0) {
        return 1;
    } else {
        return 0;
    }
}

int main() {
    const int year = 2009;
    int month, day;
    scanf("%d %d", &month, &day);
    if (func_day(month, day, year)) {
        printf("OK!\n");
    } else {
        printf("BAD!\n");
    }
    return 0;
}
