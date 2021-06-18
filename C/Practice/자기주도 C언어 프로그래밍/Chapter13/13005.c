#include <stdio.h>

int array[100];

int list(int input) {
    if (array[input] == 0) {
        array[input] = list(input - 1) + list(input - 2);
    }
    return array[input];
}

int main() {
    int num;
    scanf("%d", &num);
    array[1] = array[2] = 1;
    printf("%d\n", list(num));
    return 0;
}
