//
// Created by HM on 2021/08/15.
//

#include <iostream>
#include <string>

int main() {
    std::string song("Falling in love with you");
    std::string elvis("Elvis Presley");
    std::string singer;

    std::cout << song << "을(를) 부른 가수는";
    std::cout << "(힌트 : 첫 글자는 " << elvis[0] << ") > ";

    getline(std::cin, singer);
    singer == elvis ? std::cout << "맞았습니다. " : std::cout << "틀렸습니다. " << elvis << "입니다. " << std::endl;
    return 0;
}