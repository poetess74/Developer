#include <stdio.h>
#include <string.h>

struct PRODUCT {
    char item[5][16];
    char name[5][20];
    int price[5];
    int amount[5];
    int bill[5];
    int buy[5];
} item;

int main() {
    strcpy(item.item[0], "아메리카노");
    strcpy(item.item[1], "카페라떼");
    strcpy(item.item[2], "플랫화이트");
    item.price[0] = 4000;
    item.price[1] = 4500;
    item.price[2] = 5000;
    item.amount[0] = 10;
    item.amount[1] = 10;
    item.amount[2] = 10;
    
    int i = 0;
    while (1) {
        printf("주문할 제품명? ");
        scanf("%s", item.name[i]);
        int flag = 0;
        for(int j = 0; j < 5; j++) {
            if (strcmp(item.name[i], item.item[j])) {
                flag = 1;
            }
        }
        if (!flag) {
            printf("일치하는 제품을 찾을 수 없습니다. \n");
            continue;
        } else if (!strcmp(item.name[i], ".")) {
            break;
        }
        printf("주문할 수량? ");
        scanf("%d", &item.buy[i]);
        if (item.amount[i] < item.buy[i]) {
            printf("재고가 부족합니다. \n");
            continue;
        }
        item.bill[i] = item.buy[i] * item.price[i];
        item.amount[i] = item.amount[i] - item.buy[i];
        printf("결제 금액: %d %s 재고: %d\n", item.bill[i], item.name[i], item.amount[i]);
        i++;
    }
    for (int j = 0; j <= i; j++) {
        printf("[%s %d원 재고:%d]\n", item.item[j], item.price[j], item.amount[j]);
    }
}
