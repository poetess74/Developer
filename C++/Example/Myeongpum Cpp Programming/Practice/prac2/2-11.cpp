//
// Created by HM on 2021/08/16.
//

#include <iostream>

int main() {
    int input, sum = 0;

    std::cout << "끝 수를 입력하세요 > ";
    std::cin >> input;

    for (int i = 1; i <= input; i++) {
        sum += i;
    }

    std::cout << "1에서 " << input << "까지의 합은 " << sum << " 입니다. " << std::endl;
    return 0;
}