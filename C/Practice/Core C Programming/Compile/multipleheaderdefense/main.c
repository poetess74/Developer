#include <stdio.h>
#include "point.h"
#include "line.h"

int main() {
    POINT pt = {30, 40};
    LINE ln1 = {origin, pt};
    PRT_POINT(ln1.start);
    PRT_POINT(ln1.end);
    printf("LENGTH : %.2f\n", get_length(&ln1.start, &ln1.end));

    return 0;
}
