//
// Created by HM on 2021/08/19.
//

#include <iostream>

namespace Practice_33 {
    class Account {
        std::string user;
        int uid, balance;
    public:
        Account(std::string, int, int);
        std::string getOwner();
        void deposit(int insert);
        int withdraw(int output);
        int inquiry();
    };

    Account::Account(std::string name, int uid, int initBalance) : user(name), uid(uid), balance(initBalance) {}

    std::string Account::getOwner() { return user; }
    int Account::inquiry() { return balance; }

    void Account::deposit(int insert) {
        balance += insert;
    }

    int Account::withdraw(int output) {
        balance -= output;
        return output;
    }
}

void print_status(Practice_33::Account);

int main() {
    Practice_33::Account kitae("Kitae", 1, 5000);
    kitae.deposit(50000);
    print_status(kitae);
    int money = kitae.withdraw(20000);
    print_status(kitae);
}

void print_status(Practice_33::Account user) {
    std::cout << user.getOwner() << "의 잔액은 " << user.inquiry() << std::endl;
}

