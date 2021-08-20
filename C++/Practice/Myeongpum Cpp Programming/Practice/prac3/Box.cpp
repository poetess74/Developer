//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include "Box.h"

Practice_311::Box::Box(int w, int h) : width(w), height(h), fill('*') {}

void Practice_311::Box::setFill(char f) {
    fill = f;
}

void Practice_311::Box::setSize(int w, int h) {
    width = w; height = h;
}

void Practice_311::Box::draw() {
    for (int i = 0; i < height; i++) {
        for (int j = 0; j < width; j++) {
            std::cout << fill;
        }
        std::cout << std::endl;
    }
}