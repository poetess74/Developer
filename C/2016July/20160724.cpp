#include <stdio.h>

#define EMPTY 0
#define BLACK 1
#define WHITE 2

int x;
int y;

int board[3][3] = {
    { 0, 0, 0 },
    { 0, 0, 0 },
    { 0, 0, 0 }
};

void printBoard() {
    for (int y = 0; y < 3; y++) {
        for (int x = 0; x < 3; x++) {
            switch (board[x][y]) {
                case EMPTY:
                    printf(". ");
                    break;
                case BLACK:
                    printf("○ ");
                    break;
                case WHITE:
                    printf("● ");
                    break;
            }
        }
        printf("\n");
    }
}

int checkWinner() {
    for (int y = 0; y < 3; y++) {
        if (board[0][y] == board[1][y] && board[0][y] == board[2][y]) {
            return board[0][y];
        }
    }

    for (int x = 0; x < 3; x++) {
        if (board[x][0] == board[x][1] && board[x][0] == board[x][2]) {
            return board[x][0];
        }
    }

    if (board[0][0] == board[1][1] && board[0][0] == board[2][2]) {
        return board[0][0];
    }

    if (board[2][0] == board[1][1] && board[0][0] == board[0][2]) {
        return board[2][0];
    }

    return EMPTY;
}

int main() {
    int turn = BLACK;
    int winner;
    do {
        printBoard();
        const char* stone = (turn == BLACK) ? "○" : "●"; 
        while (true) {
            printf("%s 놓을 자리를 선택하십시오.(x,y): ", stone);
            scanf("%d,%d", &x, &y);
            if (x < 0 || x > 2 || y < 0 || y > 2 || board[x][y] != EMPTY) {
                printf("(%d,%d)에는 놓을 수 없습니다.\n", x, y);
            } else {
                board[x][y] = turn;
                turn = (turn == BLACK) ? WHITE : BLACK;
                break;
            }
        }
    } while ((winner = checkWinner()) == EMPTY);

    const char* stone = (winner == BLACK) ? "○" : "●"; 
    
    printf("%s 가 승리했습니다.\n", stone);
    printf("------\n");
    printBoard();
    printf("------\n");

    printf("게임을 종료합니다.\n");
    return 0;
}

/*
int main () {
    int wkey, wkey1, bkey, bkey1, usr;
    wkey = 0;
    wkey1 = 0;
    bkey = 0;
    bkey1 = 0;
    usr = 0;
    printf("오목 게임\n");
    while (true) {
        printf("패를 선택하십시오. (1.● 2.○) : ");
        scanf("%d", &usr);
        if (usr == 1) {
            printf("● 를 선택하셨습니다.\n");
            break;
        } else if (usr == 2) {
            printf("○ 를 선택하셨습니다.\n");
            break;
        } else {
            printf("잘못 입력하셨습니다.\n");
        }
    }
    printf("● 이 선입니다.\n");
    printf("좌표 선택 \"x 엔터후 y 입력\"\n");

    while (true) {
        while (true) {
            if (usr == 1) {
                bkey = 0;
                bkey1 = 0;
                printf("● 놓을 자리를 선택하십시오.(x,y)\n");
                scanf("%d %d", &bkey, &bkey1);
                if (bkey == wkey && bkey1 == wkey1) {
                    printf("동시에 놓을 수 없습니다.\n");
                    bkey = 0;
                    bkey1 = 0;
                }
                if (bkey == 0 && bkey1 == 0) {
                    printf("선택한 자리(x : 없음, y : 없음)\n");
                } else {
                    printf("선택한 자리(x : %d, y : %d)\n", bkey, bkey1);
                    usr = 2;
                    break;
                }
            }
        }

        while (true) {
            if (usr == 2) {
                wkey = 0;
                wkey1 = 0;
                printf("○ 놓을 자리를 선택하십시오.(x,y)\n");
                scanf("%d %d", &wkey, &wkey1);
                if (bkey == wkey && bkey1 == wkey1) {
                    printf("동시에 놓을 수 없습니다.\n");
                    wkey = 0;   
                    wkey1 = 0;
                }
                if (wkey == 0 && wkey1 == 0) {
                    printf("선택한 자리(x : 없음, y : 없음)\n");
                } else {
                    printf("선택한 자리(x : %d, y : %d)\n", wkey, wkey1);
                    usr = 1;
                    break;
                }
            }
        }
    }

    printf("게임을 종료합니다.\n");
    return 0;
}
*/
