//
// Created by HM on 2021/08/19.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_EXP_H
#define MYEONGPUM_CPP_PROGRAMMING_EXP_H

namespace OpenChallenge_CH3 {
    class Exp {
        int base, _pow;
    public:
        Exp();
        Exp(int);
        Exp(int, int);

        int getValue();
        int getBase();
        int getPow();
        bool equals(Exp);
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_EXP_H
