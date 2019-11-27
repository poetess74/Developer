#include <stdio.h>
#include <string.h>

#define ITEM_MAX 5

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

void print_product(PRODUCT item) {
    printf("[%s %d원 재고:%d]\n", item.name, item.price, item.amount);
}

int main() {
    PRODUCT items[ITEM_MAX] = {
        { "아메리카노", 4000, 10 },
        { "카페라떼",   4500, 10 },
        { "플랫화이트", 5000, 10 },
        { "핫초코",     6000, 10 },
        { "아이스티",   3500, 10 }
    };

    while (1) {
        char order_product_name[20];
        int order_amount, i;

        printf("주문할 제품명? ");
        scanf("%s", order_product_name);

        if (strcmp(order_product_name, ".") == 0)
            break;

        printf("주문할 수량? ");
        scanf("%d", &order_amount);

        for (i = 0; i < ITEM_MAX; i++) {
            if (strcmp(items[i].name, order_product_name) == 0) {
                if (items[i].amount < order_amount) {
                    printf("재고가 부족합니다.\n");
                } else {
                    int bill = order(&items[i], order_amount);
                    printf("결제 금액: %d  %s 재고: %d\n",
                            bill,
                            items[i].name,
                            items[i].amount);
                }

                break;
            }
        }

        if (i == ITEM_MAX)
            printf("존재하지 않는 제품입니다.\n");
        
    }

    for (int i = 0; i < ITEM_MAX; i++) {
        print_product(items[i]);
    }
}
