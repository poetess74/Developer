//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include "WordGame.h"

namespace OpenChallenge_41 {
    WordGame::WordGame(std::string init) {
        for (int i = 0; i < INPUT_COUNT_LIMIT; i++) {
            triedInput[i] = "";
        }
        triedInput[0] = init;
        index++;
    }

    int WordGame::addNewInput(std::string input) {
        for (int i = 0; i < index; i++) {
            if (triedInput[i] == input) {
                return 1;
            }
        }
        if (index < 100) {
            if (checkMatchRules(input)) {
                triedInput[index] = input;
                index++;
                return 0;
            } else {
                return 2;
            }
        } else {
            std::cout << "단어 배열에 여유 공간이 없습니다. 프로그램을 종료합니다. ";
            exit(-1);
        }
    }

    bool WordGame::checkMatchRules(std::string input) {
        char lastCheckedFront = triedInput[index - 1].at(triedInput[index - 1].length() - 3);
        char lastCheckedMid = triedInput[index - 1].at(triedInput[index - 1].length() - 2);
        char lastCheckedBack = triedInput[index - 1].at(triedInput[index - 1].length() - 1);
        char providedFront = input.at(0);
        char providedMid = input.at(1);
        char providedBack = input.at(2);

        return lastCheckedFront == providedFront && lastCheckedMid == providedMid && lastCheckedBack == providedBack;
    }
}