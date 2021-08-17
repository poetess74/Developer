//
// Created by HM on 2021/08/16.
//

#include <iostream>

#define MAX_LENGTH 100

int main() {
    char input[MAX_LENGTH];
    std::cout << "문자열 입력 > ";
    std::cin.getline(input, MAX_LENGTH, '\n');
    for (int i = 0; i < MAX_LENGTH; i++) {
        if (input[i] == '\0') {
            break;
        }
        for (int j = 0; j <= i; j++) {
            std::cout << input[j];
        }
        std::cout << std::endl;
    }
}