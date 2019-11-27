#include <stdio.h>

struct PRODUCT {
    char name[20];
    int price;
    int bill;
    int amount;
    int buy;
} item;

int order (struct PRODUCT *item, int *amount) {
    if (*amount >= item->buy) {
        item->bill = item->price * item->buy;
        item->amount = *amount - item->buy;
        return item->bill;
    } else {
        return 0;
    }
}

int main() {
    printf("제품명? ");
    scanf("%s", item.name);
    printf("가격? ");
    scanf("%d", &item.price);
    printf("재고? ");
    scanf("%d", &item.amount);
    do {
        printf("주문 수량? ");
        scanf("%d", &item.buy);
        if (order(&item, &item.amount)) {
            printf("[결제금액: %d 재고:%d]\n", item.bill , item.amount);
        } else if (item.buy) {
            printf("재고가 부족합니다. \n");
        }
    } while (item.buy != 0);
}
