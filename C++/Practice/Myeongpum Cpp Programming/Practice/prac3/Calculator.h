//
// Created by HM on 2021/08/20.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_CALCULATOR_H
#define MYEONGPUM_CPP_PROGRAMMING_CALCULATOR_H

namespace Practice_310 {
    class Add {
        int a, b;
    public:
        void setValue(int, int);
        int calculate();
    };

    class Sub {
        int a, b;
    public:
        void setValue(int, int);
        int calculate();
    };

    class Mul {
        int a, b;
    public:
        void setValue(int, int);
        int calculate();
    };

    class Div {
        int a, b;
    public:
        void setValue(int, int);
        int calculate();
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_CALCULATOR_H
