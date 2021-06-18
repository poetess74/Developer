#include <stdio.h>

int main() {
    int score;

    scanf("%d", &score);
    switch (score / 10) {
        case 10:
        case 9:
            printf("수\n");
            break;
        case 8:
            printf("우\n");
            break;
        case 7:
            printf("미\n");
            break;
        case 6:
            printf("양\n");
            break;
        default:
            printf("가\n");
            break;
    }
    return 0;
}
