#include <stdio.h>

typedef struct product {
    char name[20];
    int price;
    int amount;
} PRODUCT;

void print_product(PRODUCT item) {
    printf("[%s %d원 재고:%d]\n", item.name, item.price, item.amount);
}

int main() {
    PRODUCT item;
    printf("제품명? ");
    scanf("%s", item.name);
    printf("가격? ");
    scanf("%d", &item.price);
    printf("재고? ");
    scanf("%d", &item.amount);
    print_product(item);
}
