#include <stdio.h>
#include <stdint.h>

int num[UINT8_MAX];

void listLoad() {
    for (int i = 0; i <= UINT8_MAX; i++) {
        num[i] = i;
    }
}

void odd(int input) {
    for (int i = 1; i <= input; i++) {
        if (num[i] % 2 != 0) {
            printf("%d ", num[i]);
        }
    }
}
void even(int input) {
    for (int i = 2; i <= input; i++) {
        if (num[i] % 2 == 0) {
            printf("%d ", num[i]);
        }
    }
}

void clac(int input) {
    listLoad();
    if (input % 2 == 0) {
        even(input);
    } else {
        odd(input);
    }
}

int main() {
    int _num;
    scanf("%d", &_num);
    clac(_num);
    printf("\n");
    return 0;
}
