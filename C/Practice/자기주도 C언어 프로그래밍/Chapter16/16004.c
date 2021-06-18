#include <stdio.h>
#include <string.h>

struct point {
    float x, y;
} p1, p2, p3;

void p_input(point& p) {
    printf("점의 좌표는? (x,y) ");
    scanf("%f %f", &p.x, &p.y);
}

