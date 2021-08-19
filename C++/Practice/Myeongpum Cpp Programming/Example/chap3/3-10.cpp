//
// Created by HM on 2021/08/19.
//

#include <iostream>

namespace Example_310 {
    struct StructCircle {
    private:
        int radius;
    public:
        StructCircle(int);
        double getArea();
    };

    StructCircle::StructCircle(int r) : radius(r) { }

    double StructCircle::getArea() {
        return radius * radius * 3.141592;
    }
}

int main() {
    Example_310::StructCircle waffle(3);
    std::cout << "면적은 " << waffle.getArea();
}