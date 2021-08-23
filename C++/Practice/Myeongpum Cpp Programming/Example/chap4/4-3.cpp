//
// Created by HM on 2021/08/23.
//

#include <iostream>

namespace Example_43 {
    class Circle {
        int radius;
    public:
        Circle();
        Circle(int);
        void setRadius(int);
        double getArea();
    };

    Circle::Circle() : Circle(1) {}
    Circle::Circle(int r) : radius(r) {}

    void Circle::setRadius(int r) {
        radius = r;
    }

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_43::Circle circleArray[3] = {Example_43::Circle(10), Example_43::Circle(20), Example_43::Circle()};
    for (int i = 0; i < 3; i++) {
        std::cout << "Circle " << i << "의 면적은 " << circleArray[i].getArea() << std::endl;
    }
}