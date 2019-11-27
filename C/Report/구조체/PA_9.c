#include <stdio.h>

typedef struct product {
    char name[20];
    int price;
    int amount;
} PRODUCT;

int order(PRODUCT *item, int amount) {
    if (item->amount < amount)
        return 0;

    item->amount -= amount;

    return item->price * amount;
}

int main() {
    PRODUCT item;

    printf("제품명? ");
    scanf("%s", item.name);
    printf("가격? ");
    scanf("%d", &item.price);
    printf("재고? ");
    scanf("%d", &item.amount);

    int order_amount;
    int bill;

    while (1) {
        printf("주문 수량? ");
        scanf("%d", &order_amount);

        if (order_amount == 0)
            break;

        bill = order(&item, order_amount);

        if (bill != 0)
            printf("[결제 금액: %d 재고: %d]\n", bill, item.amount);
        else
            printf("재고가 부족합니다. \n");
    }
}
