#include <stdio.h>

struct data {
    char name [12];
    int age;
} buddy;

int main() {
    struct data self = {"홍길동", 14};
    printf("친한 친구의 이름과 나이를 입력하세요. ");
    scanf("%s %d", buddy.name, &buddy.age);
    printf("당신의 이름 : %s, 나이 : %d\n", self.name, self.age);
    printf("친구의 이름 : %s, 나이 : %d\n", buddy.name, buddy.age);
    return 0;
}
