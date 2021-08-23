//
// Created by HM on 2021/08/23.
//

#include <iostream>

namespace Example_410 {
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
    Circle::Circle(int r) : radius(r){}
    Circle::~Circle(){}

    double Circle::getArea() {
        return radius * radius * 3.141592;
    }

    void Circle::setRadius(int r) {
        radius = r;
    }
}

int main() {
    std::cout << "생성하고자 하는 원의 개수? > ";
    int count, radius, checkCircle = 0;
    std::cin >> count;
    if (count <= 0) return 0;
    Example_410::Circle *pArray = new Example_410::Circle[count];
    for (int i = 0; i < count; i++) {
        std::cout << "원" << i + 1 << ": ";
        std::cin >> radius;
        pArray[i].setRadius(radius);
    }

    Example_410::Circle *p = pArray;
    for (int i = 0; i < count; i++) {
        std::cout << p->getArea() << ' ';
        if (p->getArea() >= 100 && p->getArea() <= 200) {
            checkCircle++;
        }
        p++;
    }
    std::cout << std::endl << "면적이 100에서 200 사이인 원의 개수는 " << checkCircle << std::endl;
    delete [] pArray;
}