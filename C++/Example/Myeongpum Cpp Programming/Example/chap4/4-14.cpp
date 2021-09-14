//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include <string>

int main() {
    int sum = 0, startIndex = 0;
    std::string str;
    std::cout << "7+23+5+100+25 와 같이 덧셈 문자열을 입력하세요." << std::endl;
    std::getline(std::cin, str, '\n');
    while(true) {
        int fIndex = str.find('+', startIndex);
        if (fIndex == -1) {
            std::string part = str.substr(startIndex);
            if (part == "") break;
            std::cout << part << std::endl;
            sum += std::stoi(part);
            break;
        }
        int count = fIndex - startIndex;
        std::string part = str.substr(startIndex, count);

        std::cout << part << std::endl;
        sum += std::stoi(part);
        startIndex = fIndex + 1;
    }

    std::cout << "숫자들의 합은 " << sum;
}