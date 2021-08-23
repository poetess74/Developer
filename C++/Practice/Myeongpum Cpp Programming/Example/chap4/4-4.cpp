//
// Created by HM on 2021/08/23.
//

#include <iostream>

namespace Example_44 {
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
    Example_44::Circle circles[2][3];
    int index = 1;

    for (int i = 0; i < 2; i++) {
        for (int j = 0; j < 3; j++) {
            circles[i][j].setRadius(index);
            index++;
        }
    }

    for (int i = 0; i < 2; i++) {
        for (int j = 0; j < 3; j++) {
            std::cout << "Circle [" << i << ", " << j << "]의 면적은 ";
            std::cout << circles[i][j].getArea() << std::endl;
        }
    }
}