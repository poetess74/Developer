//
// Created by HM on 2021/08/15.
//

#include <iostream>
#include <cstring>

int main() {
    char passwd[11];

    std::cout << "프로그램을 종료하시려면 암호를 입력하세요 > " << std::endl;
    while(true) {
        std::cout << "암호 > ";
        std::cin >> passwd;
        if (strcmp(passwd, "C++") == 0) {
            std::cout << "프로그램을 정상 종료합니다. " << std::endl;
            break;
        } else {
            std::cout << "암호가 틀립니다~~" << std::endl;
        }
    }
}