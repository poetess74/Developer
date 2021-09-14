#include <iostream>
#include <string>
#include <random>
#include <cmath>

namespace Bitcoin {
    class Random {
        std::mt19937 gen;
    public:
        Random(std::mt19937);
        int getRandomValue(int);
        float getRandomValue();
    };

    Random::Random(std::mt19937 source) {
        gen = source;
    }

    int Random::getRandomValue(int max) {
        std::uniform_int_distribution<int> dis(0, max);
        return dis(gen);
    }

    float Random::getRandomValue() {
        std::uniform_real_distribution<float> dis(0, 700000);
        return dis(gen);
    }

    class News {
        std::string goodNews[4];
        std::string badNews[4];
    public:
        std::string getNews();
    };

    class Trade {
        int stockCount;
        float debit;
    public:
        Trade(int defaultDebit = 0);
        ~Trade();

        int getStockCount();
        float getCurrentDebit();

        void deposit(float);
        void withdraw(float, float);

        void buyBitcoin(float, int, float);
        void sellBitcoin(float, int, float);
    };

    Trade::Trade(int defaultDebit) {
        debit = defaultDebit;
        stockCount = 0;
        std::cout << "계좌 개설 완료. 현재 잔고 " << debit << "원. " << std::endl << "저희와 거래해 주셔서 감사합니다. " << std::endl;
    }

    Trade::~Trade() {
        std::cout << "계좌 폐쇄 완료. " << std::endl << "더 나은 모습으로 찾아 뵙겠습니다. " << std::endl;
    }

    float Trade::getCurrentDebit() {
        return debit;
    }

    int Trade::getStockCount() {
        return stockCount;
    }

    void Trade::deposit(float money) {
        debit += money;
        std::cout << money << "원이 입금되었습니다. 잔고 " << debit << "원" << std::endl;
    }

    void Trade::withdraw(float money, float fee) {
        if(debit - (money + fee) < 0) {
            std::cout << money << "원을 출금할 수 없습니다. " << std::endl;
            std::cout << "출금 금액이 수수료를 포함한 " << money + fee << "원이 잔고에 있는지 다시 한번 확인해 주세요. " << std::endl;
        } else {
            debit -= money + fee;
            std::cout << money << "원이 출금되었습니다. 잔고 " << debit << "원" << std::endl;
        }
    }

    void Trade::buyBitcoin(float price, int count, float fee) {
        debit -= price * count + fee;
        stockCount += count;
        std::cout << "BTC 매수 체결 " << count << "주, " << price << "원, 수수료 " << fee << std::endl;
    }

    void Trade::sellBitcoin(float price, int count, float fee) {
        debit += price * count - fee;
        stockCount -= count;
        std::cout << "BTC 매도 체결 " << count << "주, " << price << "원, 수수료 " << fee << std::endl;
    }

    class UI {
    public:
        void welcome();
    };

    void UI::welcome() {
        std::cout << "비트코인 모의투자 프로그램에 오신 것을 환영합니다. " << std::endl;
        std::cout << "본 프로그램은 특정 상품이나 서비스의 판매나 투자권유 또는 조언을 위하여 제작된 것이 아닙니다." << std::endl;
    }
}


int main() {
    Bitcoin::UI shortcut = Bitcoin::UI();

    std::string input;
    std::string value;
    std::string count;

    shortcut.welcome();
    std::cout << "[필수] 비트코인 모의투자를 위한 계좌 개설을 진행하시겠습니까? (Y/n) > ";
    getline(std::cin, input);

    if(input == "n" || input == "N") {
        std::cout << "계좌 개설을 필수로 진행하여야 합니다. 프로그램을 종료합니다. " << std::endl;
        return 1;
    }
    
    std::cout << "계좌 개설을 진행 합니다. 개설 진행 중 입금할 금액을 입력하여 주십시오 > ";
    getline(std::cin, input);
    if(input == "") { input = "0"; }
    Bitcoin::Trade account = Bitcoin::Trade(stoi(input));
    Bitcoin::News brodcast = Bitcoin::News();

    std::random_device rd;
    std::mt19937 gen(rd());
    Bitcoin::Random price = Bitcoin::Random(gen);
    Bitcoin::Random random = Bitcoin::Random(gen);

    float acceptPrice, cntPrice, maxCount;

    std::string goodNews[4] = {
        "비트코인 결제 시스템 도입, 비트코인 보편화되나?", 
        "비트코인으로 자동차 구매 가능.. 테슬라서 첫 도입", 
        "비트코인 너도나도 투자.. 투자시 유의사항은?",
        "개인들 반대로 비트코인 규제 결국 백지화"
    };

    std::string badNews[4] = {
        "비트코인 결제 시스템 결국 무산, 기존 업계 曰 시장 혼란 우려",
        "비트코인 널뛰기 가격 때문에... 테슬라 결국 비트코인 결제 중단",
        "비트코인 폭락으로 개인 패닉셀, 역대 최고치",
        "비트코인 규제 오늘부터 시행 .. 무엇이 달라지나?"
    };


    while(true) {
        std::cout << "진행하실 작업을 선택하여 주십시오. " << std::endl;
        std::cout << "1. 매수, 2. 매도, 3. 잔고, 5. 입금, 6. 출금, 8. 뉴스, 9. 도움말, 0. 폐쇄" << std::endl;
        std::cout << "> ";
        getline(std::cin, input);
        if(input == "") { continue; }

        if(stoi(input) == 1) {
            acceptPrice = price.getRandomValue();

            std::cout << "현재 비트코인 금액은 " << acceptPrice << "입니다. " << std::endl;
            std::cout << "비트코인을 매수할 금액을 입력하세요. > ";
            getline(std::cin, value);
            if (value == "" || stoi(value) == 0) { continue; }

            float debitValue = account.getCurrentDebit();
            maxCount = std::trunc(debitValue / stof(value));

            if (maxCount < 0) { maxCount = 0; }
            std::cout << "비트코인 수량을 입력하세요. (가능: " << maxCount << ") > ";
            getline(std::cin, count);
            if (count == "" || stoi(count) == 0) { continue; }
            if (stoi(count) > maxCount) { 
                std::cout << "주문 가능 수량을 초과하였습니다. 미수 거래는 아직 지원하지 않습니다. (증거금 100%)" << std::endl;
                continue;
            }
            std::cout << "비트코인 가격 " << value << ", " << count << "주 주문 전송중..." << std::endl;

            cntPrice = price.getRandomValue();
            if (cntPrice <= std::stof(value)) {
                account.buyBitcoin(cntPrice, stoi(count), 0.002f);
            } else {
                std::cout << "BTC 미체결 " << count << "주, " << value << "원" << std::endl;
            }
        } else if(stoi(input) == 2) {
            acceptPrice = price.getRandomValue();

            std::cout << "현재 비트코인 금액은 " << acceptPrice << "입니다. " << std::endl;
            std::cout << "비트코인을 매도할 금액을 입력하세요. > ";
            getline(std::cin, value);
            if (value == "" || stoi(value) == 0) { continue; }

            maxCount = account.getStockCount();

            std::cout << "비트코인 수량을 입력하세요. (가능: " << maxCount << ") > ";
            getline(std::cin, count);
            if (count == "" || stoi(count) == 0) { continue; }
            if (stoi(count) > maxCount) { 
                std::cout << "주문 가능 수량을 초과하였습니다. 보유 수량보다 더 많이 매도할 수 없습니다. " << std::endl;
                continue;
            }
            std::cout << "비트코인 가격 " << value << ", " << count << "주 주문 전송중..." << std::endl;

            cntPrice = price.getRandomValue();
            if (cntPrice >= std::stof(value)) {
                account.sellBitcoin(cntPrice, stoi(count), 0.005f);
            } else {
                std::cout << "BTC 미체결 " << count << "주, " << value << "원" << std::endl;
            }
        } else if(stoi(input) == 3) {
            cntPrice = price.getRandomValue();
            std::cout << "현재 계좌 잔고에는 " << account.getCurrentDebit() << ", 비트코인 " << account.getStockCount() << "개가 있습니다. " << std::endl;
        } else if(stoi(input) == 5) {
            std::cout << "입금하실 금액을 입력하세요 > ";
            getline(std::cin, input);
            if (input == "") { continue; }
            account.deposit(stof(input));
        } else if(stoi(input) == 6) {
            std::cout << "출금하실 금액을 입력하세요 > ";
            getline(std::cin, input);
            if (input == "") { continue; }
            account.withdraw(stof(input), 500);
        } else if(stoi(input) == 8) {
            if(random.getRandomValue(1) == 0) {
                std::cout << goodNews[random.getRandomValue(4)] << std::endl;
            } else {
                std::cout << badNews[random.getRandomValue(4)] << std::endl;
            }
        } else if(stoi(input) == 9) {
            shortcut.welcome();
        } else if(stoi(input) == 0) {
            break;
        } else {
            std::cout << "잘못된 명령입니다. 다시 시도하세요. " << std::endl;
        }
    }

    return 0;
}

