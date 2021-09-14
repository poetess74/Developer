//
// Created by HM on 2021/08/16.
//

#include <iostream>

int main() {
    int inputA, inputB;

    std::cout << "두수를 입력하여라 > ";
    std::cin >> inputA >> inputB;
    std::cout << "큰수 = ";
    inputA < inputB ? std::cout << inputB : std::cout << inputA;

    return 0;
}