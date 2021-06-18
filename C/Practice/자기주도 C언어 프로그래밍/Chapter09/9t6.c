#include <stdio.h>
#include <limits.h>

int main() {
    char C[6] = {'J', 'U', 'N', 'G', 'O', 'L'}, input;
    int num = INT_MIN;

    scanf("%c", &input);
    for (int i = 0; i < 6; i++) {
        if (C[i] == input) {
            num = i;
            break;
        }
    }
    if (num == INT_MIN) {
        printf("없는 문자입니다.\n");
    } else {
        printf("%d\n", num);
    }
    return 0;
}
