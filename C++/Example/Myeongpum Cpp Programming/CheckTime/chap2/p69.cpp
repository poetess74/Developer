//
// Created by HM on 2021/08/15.
//

#include <iostream>

double circle_area_calc(int radius) {
    return radius * radius * 3.141592;
}

int main() {
    int radius;
    double area;

    std::cout << "반지름을 입력하세요 > ";
    std::cin >> radius;
    area = circle_area_calc(radius);

    std::cout << "원의 면적은 " << area << "입니다. " << std::endl;
    return 0;
}