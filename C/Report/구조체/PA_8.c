#include <stdio.h>

struct PRODUCT {
    char name[20];
    int price;
    int amount;
} item;

void print_product(struct PRODUCT item) {
    printf("[%s %d원 재고:%d]\n", item.name, item.price, item.amount);
}

int main() {
    printf("제품명? ");
    scanf("%s", item.name);
    printf("가격? ");
    scanf("%d", &item.price);
    printf("재고? ");
    scanf("%d", &item.amount);
    print_product(item);
}
