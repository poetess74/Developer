//
// Created by HM on 2021/08/19.
//

#include <iostream>
#include "Exp.h"

using namespace OpenChallenge_CH3;

int main() {
    Exp a(3, 2);
    Exp b(9);
    Exp c;

    std::cout << a.getValue() << ' ' << b.getValue() << ' ' << c.getValue() << std::endl;
    std::cout << "a의 베이스 " << a.getBase() << ", " << "지수 " << a.getPow() << std::endl;

    a.equals(b) ? std::cout << "same" << std::endl : std::cout << "not same" << std::endl;
}