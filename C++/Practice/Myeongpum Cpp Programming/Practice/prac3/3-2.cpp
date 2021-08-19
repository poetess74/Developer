//
// Created by HM on 2021/08/19.
//

#include <iostream>
#include <string>

#define MAX_LENGTH 10

namespace Practice_32 {
    class Date {
        int year, month, day;
    public:
        Date(int, int, int);
        Date(std::string);
        void show();
        int getYear();
        int getMonth();
        int getDay();
    };

    Date::Date(int y, int m, int d) : year(y), month(m), day(d) {}

    Date::Date(std::string input) {
        char dim[3][MAX_LENGTH] = {0};
        int index = 0, count = 0;

        for (int i = 0; i < MAX_LENGTH; i++) {
            if (input[i] == '\0') { break; }
            if (input[i] == '/') {
                index++;
                count = 0;
                continue;
            }
            dim[index][count] = input[i];
            count++;
        }

        year = atoi(dim[0]);
        month = atoi(dim[1]);
        day = atoi(dim[2]);
    }

    void Date::show() {
        std::cout << year << "년 " << month << "월 " << day << "일 " << std::endl;
    }

    int Date::getYear() { return year; }
    int Date::getMonth() { return month; }
    int Date::getDay() { return day; }
}

int main() {
    Practice_32::Date birth(2014, 3, 20);
    Practice_32::Date independenceDay("1945/8/15");

    independenceDay.show();
    std::cout << birth.getYear() << ", " << birth.getMonth() << ", " << birth.getDay() << std::endl;
}