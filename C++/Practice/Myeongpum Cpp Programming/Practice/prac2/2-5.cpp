//
// Created by HM on 2021/08/16.
//

#include <iostream>

int main() {
    int char_match = 0;
    char input[100];

    std::cout << "문자들을 입력하라 (100개 미만) > ";
    std::cin.getline(input, 100, '\n');

    for (int i = 0; i < 100; i++) {
        if (input[i] == 'x') {
            char_match++;
        } else if (input[i] == '\0') {
            break;
        }
    }
    std::cout << "x의 개수는 " << char_match;

    return 0;
}