//
// Created by HM on 2021/08/17.
//

#include <iostream>

namespace Example_34 {
    class Circle {
    public:
        int radius;
        Circle();
        Circle(int);
        double getArea();
    };

    Circle::Circle() : Circle(1) { }

    Circle::Circle(int r) {
        radius = r;
        std::cout << "반지름이 " << radius << "인 원 생성" << std::endl;
    }

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_34::Circle donut;
    double area = donut.getArea();
    std::cout << "donut 면적은 " << area << std::endl;

    Example_34::Circle pizza(30);
    area = pizza.getArea();
    std::cout << "pizza 면적은 " << area << std::endl;
}