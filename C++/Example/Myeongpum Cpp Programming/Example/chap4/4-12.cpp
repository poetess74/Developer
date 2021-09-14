//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include <string>

int main() {
    std::string names[5];

    for (int i = 0; i < 5; i++) {
        std::cout << "이름 > ";
        std::getline(std::cin, names[i], '\n');
    }

    std::string latter = names[0];
    for (int i = 1; i < 5; i++) {
        if (latter < names[i]) {
            latter = names[i];
        }
    }

    std::cout << "사전에서 가장 뒤에 나오는 문자열은 " << latter << std::endl;
}