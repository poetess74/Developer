//
// Created by HM on 2021/08/16.
//

#include <iostream>
#include <cstring>

int main() {
    char inputA[10], inputB[10];

    std::cout << "새로운 암호를 입력하세요 > ";
    std::cin.getline(inputA, 10, '\n');
    std::cout << "새로운 암호를 다시 한번 입력하세요 > ";
    std::cin.getline(inputB, 10, '\n');
    strcmp(inputA, inputB) == 0 ? std::cout << "같습니다" : std::cout << "같지 않습니다";
    return 0;
}