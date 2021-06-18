//Unstable
#include <stdio.h>

int main() {
    int row, col;
    scanf("%d %d", &row, &col);
    for (int i = 1; i <= row; i++) {
        printf("%d ", i);
        for (int j = row; j <= col; j += row) {
            printf("%d ", j);
        }
        printf("\n");
    }
    return 0;
}
