//
// Created by HM on 2021/08/23.
//

#include <iostream>

int main() {
    std::cout << "입력할 정수의 개수는? > ";
    int count;
    std::cin >> count;
    if (count <= 0) return 0;

    int *p = new int[count];
    if (!p) {
        std::cout << "메모리를 할당할 수 없습니다. ";
        return 1;
    }

    for (int i = 0; i < count; i++) {
        std::cout << i + 1 << "번째 정수: ";
        std::cin >> p[i];
    }

    int sum = 0;
    for (int i = 0; i < count; i++) {
        sum += p[i];
    }
    std::cout << "평균 = " << sum / count << std::endl;
    delete [] p;
}