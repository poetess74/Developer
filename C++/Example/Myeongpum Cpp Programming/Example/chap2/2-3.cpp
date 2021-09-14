//
// Created by HM on 2021/08/15.
//

#include <iostream>

int main() {
    int width, height, area;

    std::cout << "너비를 입력하세요 > ";
    std::cin >> width;

    std::cout << "높이를 입력하세요 > ";
    std::cin >> height;

    area = width * height;
    std::cout << "면적은 " << area << std::endl;

    return 0;
}