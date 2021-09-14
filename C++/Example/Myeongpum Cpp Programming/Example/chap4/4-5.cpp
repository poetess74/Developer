//
// Created by HM on 2021/08/23.
//

#include <iostream>

int main() {
    int *p;
    p = new int;
    if (!p) {
        std::cout << "메모리를 할당할 수 없습니다. ";
        return 1;
    }

    *p = 5;
    int n = *p;
    std::cout << "*p = " << *p << std::endl;
    std::cout << "n = " << n << std::endl;

    delete p;
}