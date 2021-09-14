//
// Created by HM on 2021/08/20.
//

#include <iostream>

namespace Example_41 {
    class Circle {
        int radius;
    public:
        Circle();
        Circle(int);
        double getArea();
    };

    Circle::Circle() : Circle(1) {}
    Circle::Circle(int rad) : radius(rad) {}

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_41::Circle donut;
    Example_41::Circle pizza(30);

    std::cout << donut.getArea() << std::endl;

    Example_41::Circle *pointer;
    pointer = &donut;
    std::cout << pointer->getArea() << std::endl;
    std::cout << (*pointer).getArea() << std::endl;

    pointer = &pizza;
    std::cout << pointer->getArea() << std::endl;
    std::cout << (*pointer).getArea() << std::endl;
}