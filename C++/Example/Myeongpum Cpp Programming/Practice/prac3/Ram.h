//
// Created by HM on 2021/08/20.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_RAM_H
#define MYEONGPUM_CPP_PROGRAMMING_RAM_H

#define MEM_SIZE 1024 * 100

namespace Practice_312 {
    class Ram {
        char mem[MEM_SIZE];
        int size;
    public:
        Ram();
        ~Ram();
        char read(int);
        void write(int, char);
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_RAM_H
