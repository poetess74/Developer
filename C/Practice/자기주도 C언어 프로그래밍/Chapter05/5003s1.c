#include <stdio.h>

int main() {
    int age;
    scanf("%d", &age);
    if (age >= 20) {
        printf("성인입니다.\n");
    } else {
        printf("당신은 %d년 후에 성인이 됩니다.\n", 20 - age);
    }
    return 0;
}
