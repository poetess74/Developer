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

// PRODUCT 구조체를 매개변수로 받아 제품정보를 출력하는 함수
void print_product(PRODUCT item) {
    printf("[%s %d원 재고:%d]\n", item.name, item.price, item.amount);
}

int main() {
    // item 을 담을 배열을 items 라는 이름으로 선언
    PRODUCT items[ITEM_MAX];
    int count;

    // 최대 5개의 제품 정보를 입력 받아 저장하는 for 문
    for (count = 0; count < ITEM_MAX; count++) {
        printf("제품명? ");
        scanf("%s", items[count].name);

        if (strcmp(items[count].name, ".") == 0)
            // 만약 '.' 이 입력되면 입력 종료
            break;

        printf("가격 재고? ");
        scanf("%d %d", &items[count].price, &items[count].amount);
    }

    // 입력된 제품을 출력하는 for 문
    for (int i = 0; i < count; i++) {
        print_product(items[i]);
    }
}
