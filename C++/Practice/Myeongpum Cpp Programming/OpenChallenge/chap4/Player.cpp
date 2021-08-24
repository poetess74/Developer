//
// Created by HM on 2021/08/24.
//

#include "Player.h"

namespace OpenChallenge_41 {
    Player::Player() {}
    Player::Player(std::string name) : name(name) {}

    void Player::setName(std::string name) {
        this->name = name;
    }

    std::string Player::getName() {
        return name;
    }
}