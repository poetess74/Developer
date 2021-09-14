//
// Created by HM on 2021/08/17.
//

#include <iostream>

namespace Example_35 {
    class Point {
        int x, y;
    public:
        Point();
        Point(int, int);
        void show();
    };

    Point::Point() : Point(0, 0) { }
    Point::Point(int a, int b) : x(a), y(b) { }

    void Point::show() {
        std::cout << "(" << x << ", " << y << ")" << std::endl;
    }
}

int main() {
    Example_35::Point origin;
    Example_35::Point target(10, 20);
    origin.show();
    target.show();
}