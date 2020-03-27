//Unstable
#include <stdio.h>

int output(int input) {
    if (input - 5) {
        return input / 2;
    }
    return output(input--);
}

int main() {
    int num;
    scanf("%d", &num);
    printf("%d\n", output(num));
    return 0;
}
