//
// Created by HM on 2021/08/19.
//

#include <iostream>

namespace Example_38 {
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

    Circle globalDonut(1000);
    Circle globalPizza(2000);

    void f() {
        Circle fDonut(100);
        Circle fPizza(200);
    }
}

int main() {
    Example_38::Circle mainDonut;
    Example_38::Circle mainPizza(30);
    Example_38::f();
}