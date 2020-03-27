#include <stdio.h>

struct privacy {
    char name[12], phone[14], adress[9];
} stu;

void input() {
    scanf("%s %s %s", stu.name, stu.phone, stu.adress);
}

void output() {
    printf("이름 : %s\n전화번호 : %s\n주소 : %s\n", stu.name, stu.phone, stu.adress);
}

int main() {
    input();
    output();
    return 0;
}
