//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include <cstdlib>
#include <ctime>
#include "Random.h"

namespace Practice_35 {
    class Random {
        int randomize(int, int);
    public:
        Random();
        int next();
        int nextInRange(int, int);
    };

    Random::Random() {
        srand((unsigned) time(NULL));
    }

    int Random::randomize(int start, int end) {
        return rand() % (end - start + 1) + start;
    }

    int Random::next() {
        return randomize(0, RAND_MAX);
    }

    int Random::nextInRange(int start, int end) {
        return randomize(start, end);
    }
}

int main() {
    Practice_35::Random random;
    std::cout << "-- 0에서 " << RAND_MAX << "까지의 랜덤 정수 " << GET_RAND << " 개 --" << std::endl;
    for (int i = 0; i < GET_RAND; i++) {
        std::cout << random.next() << ' ';
    }
    std::cout << std::endl;
    std::cout << "-- 2에서 4까지의 랜덤 정수 " << GET_RAND << " 개 --" << std::endl;
    for (int i = 0; i < GET_RAND; i++) {
        std::cout << random.nextInRange(2, 4) << ' ';
    }
    std::cout << std::endl;
}