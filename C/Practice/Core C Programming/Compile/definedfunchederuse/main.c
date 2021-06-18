#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "func.h"

int main() {
    int array[6] = {0};
    srand((unsigned int)time(NULL));

    for (int i = 0; i < 6; i++) {
        array[i] = rand() % 100;
    }
    
    printf("ARRAY : ");
    print_array(array, 6);
    
    for (int i = 0; i < 6; i++) {
        printf("%2d! = %7d\n", array[i] / 10, get_factorial(array[i] / 10));
    }
    for (int i = 0; i < 6; i += 2) {
        printf("%d and %d GCD : %d\n", array[i], array[i + 1], get_gcd(array[i], array[i + 1]));
    }
    for (int i = 0; i < 6; i += 3) {
        printf("MAX (%d, %d, %d) : %d\n", array[i], array[i + 1], array[i + 2], get_max(array[i], array[i + 1], array[i + 2]));
    }
    return 0;
}
