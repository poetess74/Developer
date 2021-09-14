//
// Created by HM on 2021/08/16.
//

#include <iostream>

int main() {
    int value = 1;

    for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
            std::cout << value << "\t";
            value++;
        }
        std::cout << std::endl;
    }

    return 0;
}