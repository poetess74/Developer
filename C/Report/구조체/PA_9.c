#include <stdio.h>

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

int main() {
    // item 변수를 PRODUCT 타입으로 선언
    PRODUCT item;

    // 제품명과 가격, 재고를 입력받고
    // PRODUCT내부의 변수에 저장
    printf("제품명? ");
    scanf("%s", item.name);
    printf("가격? ");
    scanf("%d", &item.price);
    printf("재고? ");
    scanf("%d", &item.amount);

    int order_amount;
    int bill;

    // 주문수량을 입력받아 주문처리를 하는 while 문
    while (1) {
        // 주문수량을 입력받음
        printf("주문 수량? ");
        scanf("%d", &order_amount);

        if (order_amount == 0)
            // order_amount 가 0이면 종료
            break;

        // bill 변수에 order 리턴값 대입
        bill = order(&item, order_amount);

        if (bill != 0)
            // bill 이 0이면 재고가 부족
            printf("[결제 금액: %d 재고: %d]\n", bill, item.amount);
        else
            // 0이 아니면 결제 성공
            printf("재고가 부족합니다. \n");
    }
}
