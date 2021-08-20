//
// Created by HM on 2021/08/20.
//

#include <iostream>
#include <string>

namespace Practice_38 {
    class Integer {
        int value;
    public:
        Integer(int);
        Integer(std::string);
        bool isEven();
        void set(int);
        int get();
    };

    Integer::Integer(int init) : value(init) {}
    Integer::Integer(std::string init) : value(std::stoi(init)) {}

    bool Integer::isEven() { return value % 2 == 0; }
    void Integer::set(int input) { value = input; }
    int Integer::get() { return value; }
}

int main() {
    Practice_38::Integer n(30);
    std::cout << n.get() << ' ';
    n.set(50);
    std::cout << n.get() << ' ';

    Practice_38::Integer m("300");
    std::cout << m.get() << ' ';
    std::cout << m.isEven();
}