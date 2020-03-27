#include <stdio.h>

int main() {
    int width, height;
    float wide; char input;

    while (input != 'n' || input != 'N'){
        printf("밑변의 길이 = ");
        scanf("%d", &width);
        printf("높이 = ");
        scanf("%d", &height);
        wide = width * height / 2.0f;
        printf("입력하신 삼각형의 넓이는 %.1f입니다.\n", wide);
        printf("계속하시겠습니까? ");
        scanf(" %c", &input);
        if (input == 'n' || input == 'N') {
            break;
        }
    } 
    return 0;
}
