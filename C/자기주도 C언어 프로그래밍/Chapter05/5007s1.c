#include <stdio.h>

int main() {
    char grade; 
    scanf("%c", &grade);
    switch (grade) {
        case 'A':
            printf("매우잘함\n");
            break;
        case 'B':
            printf("잘함\n");
            break;
        case 'C':
            printf("보통임\n");
            break;
        case 'D':
            printf("노력요함\n");
            break;
        case 'F':
            printf("낙제\n");
            break;
        default:
            printf("잘못입력");
            break;
    }
    return 0;
}
