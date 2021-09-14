//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include <cstdlib>
#include <ctime>
#include "Random.h"

namespace Practice_36 {
    class EvenRandom {
        int randomize(int, int);
    public:
        EvenRandom();
        int next();
        int nextInRange(int, int);
    };

    EvenRandom::EvenRandom() {
        srand((unsigned) time(NULL));
    }

    int EvenRandom::randomize(int start, int end) {
        int result;
        do {
            result = rand() % (end - start + 1) + start;
        } while (result % 2 != 0);
        return result;
    }

    int EvenRandom::next() {
        return randomize(0, RAND_MAX);
    }

    int EvenRandom::nextInRange(int start, int end) {
        return randomize(start, end);
    }
}

int main() {
    Practice_36::EvenRandom random;
    std::cout << "-- 0에서 " << RAND_MAX << "까지의 랜덤 정수 " << GET_RAND << " 개 --" << std::endl;
    for (int i = 0; i < GET_RAND; i++) {
        std::cout << random.next() << ' ';
    }
    std::cout << std::endl;
    std::cout << "-- 2에서 10까지의 랜덤 정수 " << GET_RAND << " 개 --" << std::endl;
    for (int i = 0; i < GET_RAND; i++) {
        std::cout << random.nextInRange(2, 10) << ' ';
    }
    std::cout << std::endl;
}