//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include <string>

int main() {
    std::string  str;
    std::cout << "아래에 문자열을 입력하세요, 빈 칸이 있어도 됩니다. (한글 안됨) > " << std::endl;
    getline(std::cin, str, '\n');
    for (int i = 0; i < str.length(); i++) {
        std::string first = str.substr(0, 1);
        std::string sub = str.substr(1, str.length() - 1);
        str = sub + first;
        std::cout << str << std::endl;
    }
}