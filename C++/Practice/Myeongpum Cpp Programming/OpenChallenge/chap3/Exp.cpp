//
// Created by HM on 2021/08/19.
//

#include <cmath>
#include "Exp.h"

using namespace OpenChallenge_CH3;

Exp::Exp() : Exp(1, 1) { }
Exp::Exp(int b) : Exp(b, 1) { }
Exp::Exp(int b, int p) : base(b), _pow(p) { }

int Exp::getValue() {
    return pow(base, _pow);
}

bool Exp::equals(Exp target) {
    return getValue() == target.getValue();
}

int Exp::getBase() {
    return base;
}

int Exp::getPow() {
    return _pow;
}