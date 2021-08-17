//
// Created by HM on 2021/08/16.
//

#include <iostream>
#include "simple_print.h"

using namespace std;

void show_menu();
void order_menu(int, int);
bool equal(int);
void end_message();

int main() {
    int menu, count;

    welcome_message();
    while (true) {
        show_menu();
        cin >> menu;
        if (!equal(menu)) {
            continue;
        } else if (menu == 4) {
            end_message();
            break;
        }
        print("몇인분? > ");
        cin >> count;
        order_menu(menu, count);
    }

    return 0;
}

// ---- Required func
void welcome_message() {
    println("***** 승리장에 오신 것을 환영합니다. *****");
}

void show_menu() {
    print("짬뽕: 1, 자장: 2, 군만두: 3, 종료: 4 > ");
}

void order_menu(int menu, int count) {
    switch (menu) {
        case 1: show_order("짬뽕", count); break;
        case 2: show_order("자장", count); break;
        case 3: show_order("군만두", count); break;
    }
}

void show_order(string menu, int count) {
    cout << menu << " " << count << "인분 나왔습니다. " << endl;
}

bool equal(int input) {
    switch (input) {
        case 1: case 2: case 3: case 4:
            return true;
        default:
            println("다시 주문하세요!!");
            return false;
    }
}

void end_message() {
    println("오늘 영업은 끝났습니다. ");
}
