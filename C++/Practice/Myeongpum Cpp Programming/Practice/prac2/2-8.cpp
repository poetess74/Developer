//
// Created by HM on 2021/08/16.
//

#include <iostream>

#define NAME_COUNT 5
#define NAME_LIMIT 100

int main() {
    int names_length[NAME_COUNT], longest_length = INT8_MIN, longest_index = 0;
    char names[NAME_COUNT][NAME_LIMIT];

    std::cout << "5명의 이름을 ';'으로 구분하여 입력하세요." << std::endl;
    std::cout << "> ";
    for (int i = 0; i < NAME_COUNT; i++) {
        std::cin.getline(names[i], NAME_LIMIT, ';');
        std::cout << i + 1 << " : " << names[i] << std::endl;
    }
    for (int i = 0; i < NAME_COUNT; i++) {
        for (int j = 0; j < NAME_LIMIT; j++) {
            if (names[i][j] == '\0') {
                names_length[i] = j;
                break;
            }
        }
    }

    for (int i = 0; i < NAME_COUNT; i++) {
        longest_length = longest_length < names_length[i] ? names_length[i] : longest_length;
    }

    for (int i = 0; i < NAME_COUNT; i++) {
        if (names_length[i] == longest_length) {
            longest_index = i;
            break;
        }
    }

    std::cout << "가장 긴 이름은 " << names[longest_index];
}