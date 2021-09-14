//
// Created by HM on 2021/08/25.
//

#include <iostream>

namespace Practice_41 {
    class Color {
        int red, green, blue;
    public:
        Color();
        Color(int, int, int);
        void setColor(int, int, int);
        void show();
    };

    Color::Color() : Color(0, 0, 0) {}
    Color::Color(int r, int g, int b) : red(r), green(g), blue(b) {}

    void Color::setColor(int r, int g, int b) {
        red = r; green = g; blue = b;
    }

    void Color::show() {
        std::cout << red << ' ' << green << ' ' << blue << std::endl;
    }
}

int main() {
    Practice_41::Color screenColor(255, 0, 0);
    Practice_41::Color *p;

    p = &screenColor;
    p->show();

    Practice_41::Color colors[3];
    p = colors;
    p->setColor(255, 0, 0);
    p++;
    p->setColor(0, 255, 0);
    p++;
    p->setColor(0, 0, 255);

    p = colors;
    for (int i = 0; i < 3; i++) {
        p->show();
        p++;
    }
}