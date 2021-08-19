//
// Created by HM on 2021/08/19.
//

#include <iostream>

namespace Example_37 {
    class Circle {
        int radius;
    public:
        Circle();
        Circle(int);
        ~Circle();
        double getArea();
    };

    Circle::Circle() : Circle(1) { }

    Circle::Circle(int r) : radius(r) {
        std::cout << "반지름이 " << radius << "인 원 생성" << std::endl;
    }

    Circle::~Circle() {
        std::cout << "반지름이 " << radius << "인 원 소멸" << std::endl;
    }

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_37::Circle donut;
    Example_37::Circle pizza(30);
    return 0;
}