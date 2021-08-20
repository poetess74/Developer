//
// Created by HM on 2021/08/20.
//

#include <iostream>

namespace Example_42 {
    class Circle {
        int radius;
    public:
        Circle();
        Circle(int);
        void setRadius(int);
        double getArea();
    };

    Circle::Circle() : Circle(1) {}
    Circle::Circle(int rad) : radius(rad) {}

    void Circle::setRadius(int rad) {
        radius = rad;
    }

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_42::Circle circleArray[3];
    circleArray[0].setRadius(10);
    circleArray[1].setRadius(20);
    circleArray[2].setRadius(30);

    for (int i = 0; i < 3; i++) {
        std::cout << "Circle " << i << "의 면적은 " << circleArray[i].getArea() << std::endl;
    }

    Example_42::Circle *pointer;
    pointer = circleArray;
    for (int i = 0; i < 3; i++) {
        std::cout << "Circle " << i << "의 면적은 " << pointer->getArea() << std::endl;
        pointer++;
    }
}