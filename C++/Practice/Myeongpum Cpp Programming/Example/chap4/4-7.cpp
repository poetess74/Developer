//
// Created by HM on 2021/08/23.
//

#include <iostream>

namespace Example_47 {
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
    Example_47::Circle *p, *q;
    p = new Example_47::Circle;
    q = new Example_47::Circle(30);
    std::cout << p->getArea() << std::endl << q->getArea() << std::endl;
    delete p;
    delete q;
}
