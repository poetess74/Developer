#include <stdio.h>
#define ROW 3
#define COL 2

int main() {
    int data[ROW][COL] = {
        {10, 30}, {30, 40}, {50, 60},
    }

    for (int i = 0; i < ROW; i++) {
        for (int j = 0; j < COL; j++) {
            printf("%3d ", data[i][j]);
        }
        printf("\n");
    }
    return 0;
}
