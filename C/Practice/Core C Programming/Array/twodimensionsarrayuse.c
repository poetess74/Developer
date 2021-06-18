#include <stdio.h>
#define ROW 3
#define COL 2

int main() {
    int data[ROW][COL];
    for (int i = 0, int k = 0; i < ROW; i++) {
        for (int j = 0; j < COL; j++) {
            data[i][j] = ++k;
        }
    }

    for (int i = 0; i < ROW; i++) {
        for (int j = 0; j < COL; j++) {
            printf("%3d ", data[i][j]);
        }
        printf("\n");
    }

    printf("sizeof(data) = %d\n", sizeof(data));
    printf("sizeof(data[0]) = %d\n", sizeof(data[0]));
    printf("sizeof(data[0][0]) = %d\n", sizeof(data[0][0]));
    return 0;
}
