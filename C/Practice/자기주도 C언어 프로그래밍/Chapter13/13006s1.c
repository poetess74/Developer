//Unstable
#include <stdio.h>

int returnValue(int input) {
    if (input <= 1) {
        return 1;
    }
    return input % 10 + input / 10 + returnValue(input - 1);
}

int main() {
    int num;
    scanf("%d", &num);
    printf("%d\n", returnValue(num));
    return 0;
}
