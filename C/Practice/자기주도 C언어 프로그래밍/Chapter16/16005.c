#include <stdio.h>

struct money {
    int number;
    int won;
};

struct money max(struct money array[], int num) {
    struct money maxdata = array[0];
    for (int i = 1; i < num; i++) {
        if (maxdata.won < array[i].won) {
            maxdata = array[i];
        }
    }
    return maxdata;
}

int main() {
    struct money saving[5], king;
    for (int i = 0; i < 5; i++) {
        printf("%d번 저축금액은? ", i + 1);
        saving[i].number = i + 1;
        scanf("%d", &saving[i].won);
    }
    king = max(saving, 5);
    printf("저축왕 %d번%d원\n", king.number, king.won);
    return 0;
}
