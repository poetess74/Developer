//
// Created by HM on 2021/08/16.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_SIMPLE_PRINT_H
#define MYEONGPUM_CPP_PROGRAMMING_SIMPLE_PRINT_H

#include <iostream>

void welcome_message();
void show_order(std::string, int);

void print(std::string);
void println(std::string);

void print(std::string input) {
    std::cout << input;
}

void println(std::string input) {
    std::cout << input << std::endl;
}

#endif //MYEONGPUM_CPP_PROGRAMMING_SIMPLE_PRINT_H
