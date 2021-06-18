#include <stdio.h>

int main(int argc, char * argv[]) {
    int a, b;
    char op, ctn;

    do {
        printf("input : ");
        scanf("%d %c %d", &a, &op, &b);

        switch (op) {
            case '+':
                printf("%d %c %d = %d\n", a, op, b, a + b);
                break;
            case '-':
                printf("%d %c %d = %d\n", a, op, b, a - b);
                break;
            case '*':
                printf("%d %c %d = %d\n", a, op, b, a * b);
                break;
            case '/':
                if (b != 0) { printf("%d %c %d = %.2f\n", a, op, b, (double)a / b); } else { printf("Error\n"); }
                break;
            default:
                printf("wrong type\n");
                break;
        }
        printf("continue? : ");
        scanf(" %c", &ctn);
    } while (ctn =='Y' || ctn == 'y');

    return 0;
}
