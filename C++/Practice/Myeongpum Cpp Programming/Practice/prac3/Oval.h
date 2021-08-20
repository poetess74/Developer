//
// Created by HM on 2021/08/20.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_OVAL_H
#define MYEONGPUM_CPP_PROGRAMMING_OVAL_H

namespace Practice_39 {
    class Oval {
        int width, height;
    public:
        Oval();
        ~Oval();
        Oval(int , int);
        int getWidth();
        int getHeight();
        void set(int, int);
        void show();
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_OVAL_H
