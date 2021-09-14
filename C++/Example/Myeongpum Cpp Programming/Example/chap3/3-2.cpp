//
// Created by HM on 2021/08/17.
//

#include <iostream>
namespace Example_32 {
    class Rectangle {

    public:
        int width, height;
        int getArea();
    };

    int Rectangle::getArea() {
        return width * height;
    }
}

int main() {
    Example_32::Rectangle rect;
    rect.width = 3;
    rect.height = 5;
    std::cout << "사각형의 면적은 " << rect.getArea() << std::endl;
}