#include <stdio.h>

int func(int value) {
    int sum;
    for (int i = 1; i <= value; i++) {
        sum += i;
    }
    return sum;
}

int main(int argc, char * argv[]) {
    int input;
    scanf("%d", &input);
    printf("%d", func(input));
//    printf(func(input));
    return 0;
}
