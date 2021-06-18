//Unstable
#include <stdio.h>

int main() {
    const float avgScore[5] = {85.6, 79.5, 83.1, 80, 78.2, 75};
    float temp;
    int input[1];

    for (int i = 0; i <= 1; i++) {
        scanf("%d", &input[i]);
    }
    for (int i = 0; i <= 1; i++) {
        temp += avgScore[input[i]];
    }
    printf("%.1f\n", temp);
    return 0;
}
