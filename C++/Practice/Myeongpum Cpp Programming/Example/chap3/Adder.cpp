//
// Created by HM on 2021/08/19.
//

#include "Adder.h"

using namespace Example_311_Adder;

Adder::Adder(int a, int b) : op1(a), op2(b) { }

int Adder::process() {
    return op1 + op2;
}