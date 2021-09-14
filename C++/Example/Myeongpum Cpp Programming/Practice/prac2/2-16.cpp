//
// Created by HM on 2021/08/17.
//

#include <iostream>
#include <string>
#include "simple_print.h"

#define INPUT_LIMIT 10000
#define ENGLISH_CHAR_COUNT 26

void start_message();
void print_histogram(int*);

int main() {
    char input[INPUT_LIMIT];
    int count = 0, histogram[ENGLISH_CHAR_COUNT] = {0};

    start_message();
    std::cin.getline(input, INPUT_LIMIT, ';');

    for (int i = 0; i < INPUT_LIMIT; i++) {
        if (input[i] == '\0') { break; }
        if (std::isalpha(input[i])) {
            input[i] = tolower(input[i]);
            count++;
            for (int j = 0; j < ENGLISH_CHAR_COUNT; j++) {
                if (input[i] == ('a' + j)) {
                    histogram[j]++;
                }
            }
        }
    }

    std::cout << "총 알파벳 수: " << count << std::endl << std::endl;
    print_histogram(histogram);
}

void start_message() {
    println("영문 텍스트를 입력하세요. 히스토그램을 그립니다. ");
    print("텍스트의 끝은 ; 입니다. ");
    std::cout << INPUT_LIMIT << "개까지 가능합니다. " << std::endl;
}

void print_histogram(int* histogram) {
    char index = 'a';
    for (int i = 0; i < ENGLISH_CHAR_COUNT; i++) {
        std::cout << index << " (" << histogram[i] << ")\t: ";
        for (int j = 0; j < histogram[i]; j++) {
            std::cout << '*';
        }
        index++;
        std::cout << std::endl;
    }
}
