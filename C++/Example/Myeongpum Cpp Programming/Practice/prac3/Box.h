//
// Created by HM on 2021/08/20.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_BOX_H
#define MYEONGPUM_CPP_PROGRAMMING_BOX_H

namespace Practice_311 {
    class Box {
        int width, height;
        char fill;
    public:
        Box(int, int);
        void setFill(char);
        void setSize(int, int);
        void draw();
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_BOX_H
