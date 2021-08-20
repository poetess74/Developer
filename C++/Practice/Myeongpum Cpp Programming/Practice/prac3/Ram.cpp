//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include "Ram.h"

Practice_312::Ram::Ram() : size(MEM_SIZE) {
    for (int i = 0; i < MEM_SIZE; i++) {
        mem[i] = 0;
    }
}

char Practice_312::Ram::read(int addr) {
    return mem[addr];
}

void Practice_312::Ram::write(int addr, char value) {
    mem[addr] = value;
}

Practice_312::Ram::~Ram() {
    std::cout << "메모리 제거됨" << std::endl;
}