//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include <string>

int main() {
    std::string str;
    std::cout << "여러 줄의 문자열을 입력하세요. 입력의 끝은 &문자입니다. " << std::endl;
    std::getline(std::cin, str, '&');
    std::cin.ignore();

    std::string f, r;
    std::cout << std::endl << "find: ";
    std::getline(std::cin, f, '\n');
    std::cout << "replace: ";
    std::getline(std::cin, r, '\n');

    int startIndex = 0;
    while (true) {
        int fIndex = str.find(f, startIndex);
        if (fIndex == -1) {
            break;
        }
        str.replace(fIndex, f.length(), r);
        startIndex = fIndex + r.length();
    }

    std::cout << str << std::endl;
}