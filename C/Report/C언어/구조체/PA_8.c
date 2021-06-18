#include <stdio.h>

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

    // 입력된 정보를 바탕으로 제픔을 출력하는 함수 호출
    print_product(item);
}
