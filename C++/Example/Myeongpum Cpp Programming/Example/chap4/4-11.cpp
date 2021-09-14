//
// Created by HM on 2021/08/24.
//

#include <iostream>
#include <string>

int main() {
    std::string str;
    std::string address("서울시 성북구 삼선동 389");
    std::string copyAddress(address);

    char text[] = {'L', 'o', 'v', 'e', ' ', 'C', '+', '+', '\0'};
    std::string title(text);

    std::cout << str << std::endl;
    std::cout << address << std::endl;
    std::cout << copyAddress << std::endl;
    std::cout << title << std::endl;
}