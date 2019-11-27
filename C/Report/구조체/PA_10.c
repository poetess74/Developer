#include <stdio.h>
#include <string.h>

#define ITEM_MAX 5

typedef struct product {
    char name[20];
    int price;
    int amount;
} PRODUCT;

void print_product(PRODUCT item) {
    printf("[%s %d원 재고:%d]\n", item.name, item.price, item.amount);
}

int main() {
    PRODUCT items[ITEM_MAX];
    int count;

    for (count  = 0; count < ITEM_MAX; count++) {
        printf("제품명? ");
        scanf("%s", items[count].name);

        if (strcmp(items[count].name, ".") == 0)
            break;

        printf("가격 재고? ");
        scanf("%d %d", &items[count].price, &items[count].amount);
    }

    for (int i = 0; i < count; i++) {
        print_product(items[i]);
    }
}
