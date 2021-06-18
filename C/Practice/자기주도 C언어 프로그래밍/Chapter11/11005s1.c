#include <stdio.h>

int doubleTimes(int first, int last) {
    const int times = first;
    for (int i = 1; i < last; i++) {
        first = first * times;
    }
    return first;
}

int main() {
    int inputA, inputB;
    scanf("%d %d", &inputA, &inputB);
    printf("%d\n", doubleTimes(inputA, inputB));
    return 0;
}
