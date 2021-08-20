//
// Created by HM on 2021/08/20.
//

#include "Calculator.h"

void Practice_310::Add::setValue(int first, int second) {
     a = first; b = second;
}

int Practice_310::Add::calculate() {
    return a + b;
}

void Practice_310::Sub::setValue(int first, int second) {
    a = first; b = second;
}

int Practice_310::Sub::calculate() {
    return a - b;
}

void Practice_310::Mul::setValue(int first, int second) {
    a = first; b = second;
}

int Practice_310::Mul::calculate() {
    return a * b;
}

void Practice_310::Div::setValue(int first, int second) {
    a = first; b = second;
}

int Practice_310::Div::calculate() {
    return a / b;
}
