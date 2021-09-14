//
// Created by HM on 2021/08/20.
//

#include <iostream>

#define MAX_CONTAIN 10

namespace Practice_34 {
    class CoffeeMachine {
        int coffee, water, sugar;
        void formatting(int, int);
        void show();
    public:
        CoffeeMachine(int, int, int);
        void drinkEspresso();
        void drinkAmericano();
        void drinkSugarCoffee();
        void fill();
    };

    CoffeeMachine::CoffeeMachine(int coffee, int water, int sugar) : coffee(coffee), water(water), sugar(sugar) {}

    void CoffeeMachine::formatting(int mode, int count) {
        switch (mode) {
            case 0: std::cout << "커피\t: "; break;
            case 1: std::cout << "물\t: "; break;
            case 2: std::cout << "설탕\t: "; break;
        }
        for (int i = 0; i < count; i++) {
            std::cout << "■";
        }
        for (int i = 0; i < MAX_CONTAIN - count; i++) {
            std::cout << "□";
        }
        if (count < 3) {
            std::cout << " ▲";
        }
        std::cout << std::endl;
    }

    void CoffeeMachine::show() {
        std::cout << "\t커피 머신 상태" << std::endl;
        formatting(0, coffee);
        formatting(1, water);
        formatting(2, sugar);
        std::cout << std::endl;
    }

    void CoffeeMachine::fill() { coffee = 10; water = 10; sugar = 10; show(); }

    void CoffeeMachine::drinkEspresso() { coffee--; water--; show(); }
    void CoffeeMachine::drinkAmericano() { coffee--; water -= 2; show(); }
    void CoffeeMachine::drinkSugarCoffee() { coffee--; water -= 2; sugar--; show(); }
}

int main() {
    Practice_34::CoffeeMachine java(5, 10, 3);
    java.drinkEspresso();
    java.drinkAmericano();
    java.drinkSugarCoffee();
    java.fill();
}