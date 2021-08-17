//
// Created by HM on 2021/08/16.
//

#include <iostream>

int sum(int, int);

int main() {
    int input;

    std::cout << "끝 수를 입력하세요 > ";
    std::cin >> input;
    std::cout << "1에서 " << input << "까지의 합은 " << sum(1, input) << " 입니다. " << std::endl;
    return 0;
}

int sum(int start, int end) {
    int res = 0;
    for (int i = start; i <= end; i++) {
        res += i;
    }
    return res;
}