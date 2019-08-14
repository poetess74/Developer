#include <stdio.h>

void accumulator(char op, int operand);

int main() {
    while (1) {
        char op;
        int num;
        printf("input operator and number : ");
        scanf(" %c %d", &op, &num);
        if (op == '.' && num == 0) {
            break;
        }
        accumulator(op, num);
    }

    return 0;
}

void accumulator(char op, int operand) {
    static int result = 0;
    switch (op) {
        case '+':
            result += operand;
            break;
        case '-':
            result -= operand;
            break;
        case '*':
            result *= operand;
            break;
        case '/':
            result /= operand;
            break;
        default:
            return;
    }
    printf("%c %d = %d\n", op, operand, result);
}
