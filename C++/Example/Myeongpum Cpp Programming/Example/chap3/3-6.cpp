//
// Created by HM on 2021/08/17.
//

#include <iostream>

namespace Example_36 {
    class Rectangle {
        int x, y;
    public:
        Rectangle();
        Rectangle(int);
        Rectangle(int, int);
        bool isSquare();
    };

    Rectangle::Rectangle() : Rectangle(1) { }
    Rectangle::Rectangle(int w, int h) : x(w), y(h) { }
    Rectangle::Rectangle(int length) : x(length), y(length) { }

    bool Rectangle::isSquare() {
        return x == y;
    }
}

int main() {
    Example_36::Rectangle rect1;
    Example_36::Rectangle rect2(3, 5);
    Example_36::Rectangle rect3(3);

    if (rect1.isSquare()) std::cout << "rect1은(는) 정사각형이다. " << std::endl;
    if (rect2.isSquare()) std::cout << "rect2은(는) 정사각형이다. " << std::endl;
    if (rect3.isSquare()) std::cout << "rect3은(는) 정사각형이다. " << std::endl;
}