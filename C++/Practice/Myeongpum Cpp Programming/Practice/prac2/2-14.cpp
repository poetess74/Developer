//
// Created by HM on 2021/08/16.
//

#include <iostream>
#include "simple_print.h"

#define MAX_COFFEE_LENGTH 100
#define MAX_EARNINGS 20000
#define ESPRESSO 2000
#define AMERICANO 2300
#define CAPPUCCINO 2500

using namespace std;

void end_message(int);
int begin_order(int, int);

int main() {
    char coffee[MAX_COFFEE_LENGTH];
    int earnings = 0, count;
    welcome_message();
    do {
        print("주문 > ");
        cin >> coffee >> count;
        if (strcmp(coffee, "에스프레소") == 0) {
            earnings += begin_order(ESPRESSO, count);
        } else if (strcmp(coffee, "아메리카노") == 0) {
            earnings += begin_order(AMERICANO, count);
        } else if (strcmp(coffee, "카푸치노") == 0) {
            earnings += begin_order(CAPPUCCINO, count);
        }
    } while(earnings < MAX_EARNINGS);
    end_message(earnings);
    return 0;
}

void welcome_message() {
    cout << "에스프레소 " << ESPRESSO << "원" << ", ";
    cout << "아메리카노 " << AMERICANO << "원" << ", ";
    cout << "카푸치노 " << CAPPUCCINO << "원" << "입니다. " << endl;
}

int begin_order(int pay, int count) {
    int receipt = pay * count;
    cout << receipt << "원 입니다. ";
    println("맛있게 드세요. ");
    return receipt;
}

void end_message(int earnings) {
    cout << "오늘 " << earnings;
    println("원을 판매하여 카페를 닫습니다. 내일 봐요~~");
}