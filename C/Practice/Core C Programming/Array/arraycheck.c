#include <stdio.h>

int main() {
    int x[5] = {10, 20, 30, 40, 50};
    int y[5] = {10, 20, 30, 40, 50};
    int is_equal;
    
    if (x == y) {
        printf("same address\n");
    }
    is_equal = 1;
    for (i = 0; i < 5; i++) {
        if (x[i] != y[i]) {
            is_equal = 0;;
            break;
        }
    }
    if (is_equal) {
        printf("same contents\n");
    }
    return 0;
}
