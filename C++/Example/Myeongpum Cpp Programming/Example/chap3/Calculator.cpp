//
// Created by HM on 2021/08/19.
//

#include <iostream>
#include "Calculator.h"
#include "Adder.h"

using namespace Example_311_Calculator;
using namespace Example_311_Adder;

void Calculator::run() {
    int a, b;
    std::cout << "두 개의 수를 입력하세요 > ";
    std::cin >> a >> b;
    Adder adder(a, b);
    std::cout << adder.process();
}
