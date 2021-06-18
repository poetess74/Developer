#include <stdio.h>

struct data {
    char name[12];
    char schoolName[24];
    int grade;
};

int main() {
    struct data self;
    scanf("%s", self.name);
    scanf("%s", self.schoolName);
    scanf("%d", &self.grade);
    printf("%s %d학년에 재학중인 %s입니다.\n", self.schoolName, self.grade, self.name);
    return 0;
}
