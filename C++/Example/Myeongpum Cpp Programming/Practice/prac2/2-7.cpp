//
// Created by HM on 2021/08/16.
//

#include <iostream>

int main() {
    char input[100];

    while(true) {
        std::cout << "종료하고 싶으면 yes를 입력하세요 > ";
        std::cin.getline(input, 100, '\n');
        if (strcmp(input, "yes") == 0) {
            break;
        }
    }
    std::cout << "종료합니다...";
    return 0;
}