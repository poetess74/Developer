//
// Created by HM on 2021/08/16.
//

#include <iostream>

#define MAX_CHAR 100

int main() {
    char id[3][MAX_CHAR];

    std::cout << "이름은? > ";
    std::cin.getline(id[0], MAX_CHAR, '\n');
    std::cout << "주소는? > ";
    std::cin.getline(id[1], MAX_CHAR, '\n');
    std::cout << "나이는? > ";
    std::cin.getline(id[2], MAX_CHAR, '\n');

    std::cout << id[0] << ", " << id[1] << ", " << id[2] << "세";
}