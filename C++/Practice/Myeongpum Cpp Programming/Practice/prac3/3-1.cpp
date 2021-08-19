//
// Created by HM on 2021/08/19.
//

#include <iostream>

namespace Practice_31 {
    class Tower {
        int height;
    public:
        Tower();
        Tower(int);
        int getHeight();
    };

    Tower::Tower() : Tower(1) {}

    Tower::Tower(int h) : height(h) {}

    int Tower::getHeight() {
        return height;
    }
}

int main() {
    Practice_31::Tower myTower;
    Practice_31::Tower seoulTower(100);

    std::cout << "높이는 " << myTower.getHeight() << "미터" << std::endl;
    std::cout << "높이는 " << seoulTower.getHeight() << "미터" << std::endl;
}