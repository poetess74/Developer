//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include "Calculator.h"

#define MAX_LENGTH 100

int main() {
    char number[2][MAX_LENGTH];
    char op[MAX_LENGTH];

    Practice_310::Add add;
    Practice_310::Sub sub;
    Practice_310::Mul mul;
    Practice_310::Div div;

#pragma clang diagnostic push
#pragma ide diagnostic ignored "EndlessLoop"
    while(true) {
        std::cout << "두 정수와 연산자를 입력하세요 > ";

        for (int i = 0; i < 2; i++) {
            std::cin.getline(number[i], MAX_LENGTH, ' ');
        }
        std::cin >> op;

        switch (op[0]) {
            case '+':
                add.setValue(atoi(number[0]), atoi(number[1]));
                std::cout << add.calculate() << std::endl;
                break;
            case '-':
                sub.setValue(atoi(number[0]), atoi(number[1]));
                std::cout << sub.calculate() << std::endl;
                break;
            case '*':
                mul.setValue(atoi(number[0]), atoi(number[1]));
                std::cout << mul.calculate() << std::endl;
                break;
            case '/':
                div.setValue(atoi(number[0]), atoi(number[1]));
                std::cout << div.calculate() << std::endl;
                break;
            default: break;
        }
    }
#pragma clang diagnostic pop
}