//
// Created by HM on 2021/08/24.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_WORDGAME_H
#define MYEONGPUM_CPP_PROGRAMMING_WORDGAME_H

#include <iostream>

#define INPUT_COUNT_LIMIT 100

namespace OpenChallenge_41 {
    class WordGame {
        int index = 0;
        std::string triedInput[INPUT_COUNT_LIMIT];
        bool checkMatchRules(std::string);
    public:
        WordGame(std::string);
        int addNewInput(std::string);
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_WORDGAME_H
