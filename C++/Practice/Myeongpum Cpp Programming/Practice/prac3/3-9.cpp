//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include "Oval.h"

int main() {
    Practice_39::Oval a, b(3, 4);
    a.set(10, 20);
    a.show();
    std::cout << b.getWidth() << ", " << b.getHeight() << std::endl;
}