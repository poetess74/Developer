//
// Created by HM on 2021/08/24.
//

#ifndef MYEONGPUM_CPP_PROGRAMMING_PLAYER_H
#define MYEONGPUM_CPP_PROGRAMMING_PLAYER_H

#include <iostream>

namespace OpenChallenge_41 {
    class Player {
        std::string name;
    public:
        Player();
        Player(std::string);
        void setName(std::string);
        std::string getName();
    };
}

#endif //MYEONGPUM_CPP_PROGRAMMING_PLAYER_H
