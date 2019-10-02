#include <stdio.h>

int main() {
    int amount[5] = {1, 1, 5};
    int price[5] = {0};
    printf("amount = ");
    for (int i = 0; i < 5; i++) {
        printf("%d ", amount[i]);
    }
    printf("\n");

    printf("price = ");
    for (int i = 0; i < 5; i++) {
        printf("%d ", price[i]);
    }
    printf("\n");
    return 0;
}
