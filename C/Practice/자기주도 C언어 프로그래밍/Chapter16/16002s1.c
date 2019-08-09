#include <stdio.h>

struct data {
    char schoolName[24];
    int grade;
} buddy;

int main() {
    struct data self = {"제주초등학교", 6};
    scanf("%s %d", buddy.schoolName, &buddy.grade);
    printf("%s %d학년\n", self.schoolName, self.grade);
    printf("%s %d학년\n", buddy.schoolName, buddy.grade);
    return 0;
}
