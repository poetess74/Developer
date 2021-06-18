#include <stdio.h>

int main() {
    int insert;
    scanf("%d", &insert);
    if (50 >= insert) {
        for (int i = 2; i <= insert; i+=2) {
            printf("%d ", i);
        }
    }
    printf("\n");
    return 0;
}
