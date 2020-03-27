#include <stdio.h>

int main() {
    int year;
    scanf("%d", &year);
    if (year % 400 == 0) {
        printf("윤년\n");
    } else if (year % 4 == 0 && year % 100 != 0) {
        printf("윤년\n");
    } else {
        printf("평년\n");
    }
    return 0;
}
