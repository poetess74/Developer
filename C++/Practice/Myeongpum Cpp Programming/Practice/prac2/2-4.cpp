//
// Created by HM on 2021/08/16.
//

#include <iostream>

#define INPUT_LENGTH 5

int main() {
    float input[INPUT_LENGTH];
    float max = INT8_MIN;

    std::cout << "5개의 실수를 입력하여라 > ";
    for (int i = 0; i < INPUT_LENGTH; i++) {
        std::cin >> input[i];
    }
    for (int i = 0; i < INPUT_LENGTH; i++) {
        max = max > input[i] ? max : input[i];
    }
    std::cout << "제일 큰 수 = " << max;
}