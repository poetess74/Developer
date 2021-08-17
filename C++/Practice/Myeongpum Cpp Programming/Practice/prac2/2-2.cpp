//
// Created by HM on 2021/08/16.
//

#include <iostream>

int main() {
    for (int i = 1; i < 10; i++) {
        for (int j = 1; j < 10; j++) {
            std::cout << j << " * " << i << " = " << j * i << "\t";
        }
        std::cout << std::endl;
    }

    return 0;
}