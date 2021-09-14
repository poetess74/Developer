//
// Created by HM on 2021/08/16.
//

#include <iostream>

#define MAX_LENGTH 10
#define INT_LENGTH 4

void print_prompt();
void print_result(int, int, char);

int main() {
    char input[MAX_LENGTH], op;
    int first = INT8_MIN, second = INT8_MIN, lastIndex;

#pragma clang diagnostic push
#pragma ide diagnostic ignored "EndlessLoop"
    while (true) {
        print_prompt();
        std::cin.getline(input, MAX_LENGTH, '\n');
        lastIndex = 0;

        {
            char temp[INT_LENGTH] = {'\0'};

            for (int i = 0; i < MAX_LENGTH; i++) {
                if (input[i] == ' ') {
                    for (int j = lastIndex; j < i; j++) {
                        temp[j] = input[j];
                    }
                    first = atoi(temp);
                    lastIndex = i + 1;
                    break;
                }
            }
        }

        {
            char temp[INT_LENGTH] = {'\0'};

            for (int i = 0; i < INT_LENGTH; i++) { temp[i] = '\0'; }

            for (int i = lastIndex; i < MAX_LENGTH; i++) {
                if (input[i] == ' ') {
                    for (int j = lastIndex; j < i; j++) {
                        temp[0] = input[j];
                    }
                    op = temp[0];
                    lastIndex = i + 1;
                    break;
                }
            }
        }

        {
            char temp[INT_LENGTH] = {'\0'};

            for (int i = 0; i < INT_LENGTH; i++) { temp[i] = '\0'; }

            for (int i = lastIndex; i < MAX_LENGTH; i++) {
                if (input[i] == '\0') {
                    for (int j = lastIndex; j < i; j++) {
                        temp[j % lastIndex] = input[j];
                    }
                    second = atoi(temp);
                    break;
                }
            }
        }

        print_result(first, second, op);
    }
#pragma clang diagnostic pop
}

void print_prompt() {
    std::cout << "> ";
}

void print_result(int first, int second, char op) {
    std::cout << first << " " << op << " " << second << " = ";
    switch (op) {
        case '+': std::cout << first + second << std::endl; break;
        case '-': std::cout << first - second << std::endl; break;
        case '*': std::cout << first * second << std::endl; break;
        case '/': std::cout << first / second << std::endl; break;
        case '%': std::cout << first % second << std::endl; break;
        default:
            std::cout << "value can not be null" << std::endl;
            exit(-1);
    }
}
