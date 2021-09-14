//
// Created by HM on 2021/08/23.
//

#include <iostream>

namespace Example_48 {
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
    int radius;
    while (true) {
        std::cout << "정수 반지름 입력 (음수이면 종료) > ";
        std::cin >> radius;
        if (radius < 0) break;
        auto *p = new Example_48::Circle(radius);
        std::cout << "원의 면적은 " << p->getArea() << std::endl;
        delete p;
    }
}