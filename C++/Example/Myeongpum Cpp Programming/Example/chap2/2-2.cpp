//
// Created by HM on 2021/08/15.
//

#include <iostream>

double area(int r);

double area(int r) {
    return r * r * 3.141592;
}

int main() {
    int n = 3;
    char c = '#';
    std::cout << c << 5.5 << '-' << n << "hello" << true << std::endl;
    std::cout << "n + 5 = " << n + 5 << std::endl;
    std::cout << "면적은 " << area(n);
    return 0;
}