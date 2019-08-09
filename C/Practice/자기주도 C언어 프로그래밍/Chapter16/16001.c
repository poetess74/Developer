#include <stdio.h>

struct data {
    char name[20];
    int age;
};

int main() {
    struct data self;
    printf("당신의 이름은 무엇입니까? ");
    scanf("%s", self.name);
    printf("당신의 나이는 몇 살입니까? ");
    scanf("%d", &self.age);
    printf("당신의 이름은 %s이고 나이는 %d세이군요.\n", self.name, self.age);
    return 0;
}
