//
// Created by HM on 2021/08/25.
//

#include <iostream>

namespace Practice_42 {
    class average {
        int value;
    public:
        int setValue(int);
        int getValue();
    };

    int average::setValue(int value) {
        this->value = value;
    }

    int average::getValue() {
        return value;
    }
}

int main() {
    std::cout << "정수 5개 입력 > ";
    Practice_42::average average[5];

    for (int i = 0; i < 5; i++) {
        int input;
        std::cin >> input;
        average[i].setValue(input);
    }

    int sum = 0;
    for (int i = 0; i < 5; i++) {
        sum += average[i].getValue();
    }
    std::cout << "평균 " << sum / 5.0 << std::endl;
}