//Unstable
#include <stdio.h>

struct privacy {
    char name[12], phone[14], adress[9];
} stu[3];

void input() {
    for (int i = 0; i < 3; i++) {
        scanf("%s %s %s", stu[i].name, stu[i].phone, stu[i].adress);
    }
}

void sort() {
    struct privacy temp;
    for (int i = 0; i < 3; i++) {
        for (int j = i + 1; j < 3; j++) {
            if (stu[i].name > stu[i].name) {
                temp = stu[i];
                stu[i] = stu[j];
                stu[j] = temp;
            }
        }
    }
}

void output() {
    for (int i = 0; i < 3; i++) {
        printf("이름 : %s\n전화번호 : %s\n주소 : %s\n", stu[i].name, stu[i].phone, stu[i].adress);
    }
}

int main() {
    input();
    sort();
    output();
    return 0;
}
