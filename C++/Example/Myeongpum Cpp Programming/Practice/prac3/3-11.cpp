//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include "Box.h"

int main() {
    Practice_311::Box b(10, 2);
    b.draw();
    std::cout << std::endl;
    b.setSize(7, 4);
    b.setFill('^');
    b.draw();
}