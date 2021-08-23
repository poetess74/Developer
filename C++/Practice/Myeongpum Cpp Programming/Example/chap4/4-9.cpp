//
// Created by HM on 2021/08/23.
//

#include <iostream>

namespace Example_49 {
    class Circle {
        int radius;
    public:
        Circle();
        Circle(int);
        ~Circle();
        void setRadius(int);
        double getArea();
    };

    Circle::Circle() : Circle(1){}
    Circle::Circle(int r) : radius(r) {
        std::cout << "생성자 실행 radius = " << radius << std::endl;
    }
    Circle::~Circle() {
        std::cout << "소멸자 실행 radius = " << radius << std::endl;
    }

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }

    void Circle::setRadius(int r) {
        radius = r;
    }
}

int main() {
    Example_49::Circle *pArray = new Example_49::Circle[3];
    for (int i = 0; i < 3; i++) {
        pArray[i].setRadius((i + 1) * 10);
    }

    for (int i = 0; i < 3; i++) {
        std::cout << pArray[i].getArea() << std::endl;
    }

    Example_49::Circle *p = pArray;

    for (int i = 0; i < 3; i++) {
        std::cout << p->getArea() << std::endl;
        p++;
    }

    delete [] pArray;
}