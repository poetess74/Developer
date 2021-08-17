//
// Created by HM on 2021/08/17.
//

#include <iostream>

void create_circle(int);

namespace Example_33 {
    class Circle {
    public:
        int radius;
        Circle();
        Circle(int);
        double getArea();
    };

    Circle::Circle() {
        radius = 1;
        create_circle(radius);
    }

    Circle::Circle(int r) {
        radius = r;
        create_circle(radius);
    }

    double Circle::getArea() {
        return radius * radius * 3.141582;
    }
}

int main() {
    Example_33::Circle donut;
    double area = donut.getArea();
    std::cout << "donut 면적은 " << area << std::endl;

    Example_33::Circle pizza(30);
    area = pizza.getArea();
    std::cout << "pizza 면적은 " << area << std::endl;
}

void create_circle(int radius) {
    std::cout << "반지름이 " << radius << "인 원 생성" << std::endl;
}