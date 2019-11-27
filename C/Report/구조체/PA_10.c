#include <stdio.h>
#include <string.h>

int stopInput = 0;

struct PRODUCT {
    char name[5][20];
    int price[5];
    int amount[5];
} item;

int main() {
    for (int i = 0; i < 5; i++) {
        printf("제품명? ");
        scanf("%s", item.name[i]);
        if (!strcmp(item.name[i], ".")) {
            stopInput = i;
            break;
        }
        printf("가격 재고? ");
        scanf("%d %d", &item.price[i], &item.amount[i]);
        stopInput = i;
    }
    for (int i = 0; i <= stopInput; i++) {
        if (!strcmp(item.name[i], ".")) {
            break;
        }
        printf("[%s %d원 재고:%d]\n", item.name[i], item.price[i], item.amount[i]);
    }
}
