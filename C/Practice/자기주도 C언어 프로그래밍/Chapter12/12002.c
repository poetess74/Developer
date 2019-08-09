#include <stdio.h>

void input(int a[], int count) {
    printf("%d과목의 점수를 입력하세요. ", count);
    for (int i = 0; i < count; i++) {
        scanf("%d", &a[i]);
    }
}

int pass(int a[], int count) {
    int sum = 0, avg;
    for (int i = 0; i < count; i++) {
        if (a[i] < 40) {
            return 0;
        }
        sum += a[i];
    }
    avg = sum / count;
    if (avg < 60) {
        return 0;
    }
    return 1;
}

int main() {
    int score[3];
    input(score, 3);
    if (pass(score, 3)) {
        printf("축하합니다. 합격입니다. \n");
    } else {
        printf("죄송합니다. 불합격입니다. \n");
    }
    return 0;
}
