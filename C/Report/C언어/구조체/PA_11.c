#include <stdio.h>
#include <string.h>

// 가독성과 제품수량 조정을 위해 ITEM_MAX 매크로 정의
#define ITEM_MAX 5

// 구조체 product로 정의 및 PRODUCT라는 이름으로 별칭 생성
typedef struct product {
    char name[20];
    int price;
    int amount;
} PRODUCT;

// PRODUCT 구조체를 매개변수로 받아 주문처리 하는 함수
int order(PRODUCT *item, int amount) {
    if (item->amount < amount)
        // 구조체 product의 amount가 amount 보다 작을경우
        // 재고가 없으므로 0을 리턴함
        return 0;

    // 재고가 있을 경우 요구되는 만큼 재고에서 차감 후
    item->amount -= amount;

    // 구조체 product의 price의 값 * amount 로 금액 리턴
    return item->price * amount;
}

// PRODUCT 구조체를 매개변수로 받아 제품정보를 출력하는 함수
void print_product(PRODUCT item) {
    printf("[%s %d원 재고:%d]\n", item.name, item.price, item.amount);
}

int main() {
    // PRODUCT를 items 으로 선언하며 아래와 같이 미리 정의함
    PRODUCT items[ITEM_MAX] = {
        { "아메리카노", 4000, 10 },
        { "카페라떼",   4500, 10 },
        { "플랫화이트", 5000, 10 },
        { "핫초코",     6000, 10 },
        { "아이스티",   3500, 10 }
    };

    // 주문할 제품명 입력받는 while 루프
    while (1) {
        char order_product_name[20];
        int order_amount, i;

        printf("주문할 제품명? ");
        scanf("%s", order_product_name);

        if (strcmp(order_product_name, ".") == 0)
            // 만약 '.' 이 입력되면 종료
            break;

        printf("주문할 수량? ");
        scanf("%d", &order_amount);

        // 재고와 상품의 존재를 찾는 for 루프
        for (i = 0; i < ITEM_MAX; i++) {
            if (strcmp(items[i].name, order_product_name) == 0) {
            
                if (items[i].amount < order_amount) {
                    // 상품의 존재를 찾았지만 재고보다 많은 양을 구입
                    printf("재고가 부족합니다.\n");

                } else {
                    // 결제가 정상적으로 완료되었을 경우
                    int bill = order(&items[i], order_amount);
                    printf("결제 금액: %d  %s 재고: %d\n",
                            bill,
                            items[i].name,
                            items[i].amount);
                }

                // 검색이 완료되었으므로 찾는 것을 그만둠
                break;
            }
        }

        if (i == ITEM_MAX)
            // 만약 끝까지 돌았는데 상품의 존재를 찾지 못하였을 경우
            printf("존재하지 않는 제품입니다.\n");
        
    }

    // 비치된 상품과 재고를 출력하는 루프
    for (int i = 0; i < ITEM_MAX; i++) {
        print_product(items[i]);
    }
}
