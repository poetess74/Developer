#include <stdio.h>

enum direction {NORTH, SOUTH, EAST, WEST};

int main() {
    enum direction d1 = NORTH;

    d1 = EAST;
    printf("d1 = %d\n", d1);

    switch(d1) {
        case NORTH:
            printf("GO NORTH\n");
            break;
        case SOUTH:
            printf("GO SOUTH\n");
            break;
        case EAST:
            printf("GO EAST\n");
            break;
        case WEST:
            printf("GO WEST\n");
            break;
    }

    return 0;
}
