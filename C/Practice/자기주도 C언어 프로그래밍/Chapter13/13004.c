//Unstable
#include <stdio.h>

int num, array[101];

void output() {
    for (int i = 1; i <= num; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}

void dice(int level) {
    if (level > num) {
        output();
        return;
    } 
    for (int i = 1; i <= 6; i++) {
        array[level] = i;
        dice(level + 1);
    }
}

int main() {
    int _num;
    scanf("%d", &_num);
    dice(_num);
    return 0;
}
