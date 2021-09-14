//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include "Oval.h"

namespace Practice_39 {
    Oval::Oval() : Oval(1, 1) {}
    Oval::Oval(int w, int h) : width(w), height(h) {}
    Oval::~Oval() {
       std::cout << "Oval 소멸: width = " << width << ", height = " << height << std::endl;
    }

    void Oval::show() {
        std::cout << "width = " << width << ", height = " << height << std::endl;
    }

    void Oval::set(int w, int h) {
        width = w; height = h;
    }

    int Oval::getWidth() { return width; }
    int Oval::getHeight() { return height; }
}