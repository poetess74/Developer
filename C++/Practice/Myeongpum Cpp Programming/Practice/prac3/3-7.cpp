//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include <cstdlib>
#include <ctime>
#include "Random.h"

namespace Practice_37 {
    class SelectableRandom {
        int randomize(int, int, bool);
    public:
        SelectableRandom();
        int next(bool);
        int nextInRange(int, int, bool);
    };

    SelectableRandom::SelectableRandom() {
        srand((unsigned) time(NULL));
    }

    int SelectableRandom::randomize(int start, int end, bool even) {
        int result;
        if (even) {
            do {
                result = rand() % (end - start + 1) + start;
            } while (result % 2 != 0);
        } else {
            do {
                result = rand() % (end - start + 1) + start;
            } while (result % 2 == 0);
        }
        return result;
    }

    int SelectableRandom::next(bool isEven) {
        return randomize(0, RAND_MAX, isEven);
    }

    int SelectableRandom::nextInRange(int start, int end, bool isEven) {
        return randomize(start, end, isEven);
    }
}

int main() {
    Practice_37::SelectableRandom random;
    std::cout << "-- 0에서 " << RAND_MAX << "까지의 랜덤 정수 " << GET_RAND << " 개 --" << std::endl;
    for (int i = 0; i < GET_RAND; i++) {
        std::cout << random.next(true) << ' ';
    }
    std::cout << std::endl;
    std::cout << "-- 2에서 10까지의 랜덤 정수 " << GET_RAND << " 개 --" << std::endl;
    for (int i = 0; i < GET_RAND; i++) {
        std::cout << random.nextInRange(2, 10, false) << ' ';
    }
    std::cout << std::endl;
}