//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include "WordGame.h"
#include "Player.h"

void welcome_message();

int main() {
    std::string const providedWord[2] = {"아버지", "지우개"};
    int count;
    std::string input;

    welcome_message();
    std::cout << "게임에 참여하는 인원은 몇 명입니까? > ";
    std::getline(std::cin, input, '\n');
    count = atoi(input.c_str());
    if (count < 2) return -1;

    OpenChallenge_41::Player players[count];
    for (int i = 0; i < count; i++) {
        std::cout << "참가자의 이름을 입력하세요. 빈칸 없이 > ";
        std::getline(std::cin, input, '\n');
        players[i].setName(input);
    }
    std::cout << "시작하는 단어는 " << providedWord[0] << "입니다. " << std::endl;
    OpenChallenge_41::WordGame game("아버지");

    for (int i = 0;; i = (i+1) % count) {
        std::cout << players[i].getName() << " > ";
        std::getline(std::cin, input, '\n');
        int result = game.addNewInput(input);
        switch (result) {
            case 0: break;
            case 1:
                std::cout << "게임이 종료되었습니다. " << players[i].getName() << "님의 패배" << std::endl;
                std::cout << "사유: 이미 언급된 키워드";
                return 0;
            case 2:
                std::cout << "게임이 종료되었습니다. " << players[i].getName() << "님의 패배" << std::endl;
                std::cout << "사유: 게임 규칙위반 - 이전 키워드와 매치되지 않습니다";
                return 0;
        }
    }
}

void welcome_message() {
    std::cout << "끝말 잇기 게임을 시작합니다" << std::endl;
}
