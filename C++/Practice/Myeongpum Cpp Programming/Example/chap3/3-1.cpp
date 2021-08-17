//
// Created by HM on 2021/08/17.
//

#include <iostream>

namespace Example_31 {
    class Circle {
    public:
        int radius;
        double getArea();
    };

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_31::Circle donut, pizza;
    donut.radius = 1;
    double area = donut.getArea();
    std::cout << "donut 면적은 " << area << std::endl;

    pizza.radius = 30;
    area = pizza.getArea();
    std::cout << "pizza 면적은 " << area << std::endl;
}