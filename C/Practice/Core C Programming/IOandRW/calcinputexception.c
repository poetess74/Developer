#include <stdio.h>

int main() {
    int a, b; char op;

    while (1) {
        printf("INPUT : ");
        if (scanf("%d %c %d", &a, &op, &b) < 3) {
            printf("ERROR, INSERT TYPE TO <INT><CHAR><INT>\n");
            while (getchar() != '\n') {}
            continue;
        }
        if (a == 0 && op == '0' && b == 0) {
            break;
        }

        switch(op) {
            case '+':
                printf("%d + %d = %d\n", a, b, a + b);
                break;
            case '-':
                printf("%d - %d = %d\n", a, b, a - b);
                break;
            case '*':
                printf("%d * %d = %d\n", a, b, a * b);
                break;
            case '/':
                if (b != 0) {
                    printf("%d / %d = %.2f\n", a, b, (float)a / b);
                } else {
                    printf("NaN\n");
                }
                break;
            default:
                printf("ERROR, COMMAND NOT FOUND\n");
                break;
        }
    }
    return 0;
}
