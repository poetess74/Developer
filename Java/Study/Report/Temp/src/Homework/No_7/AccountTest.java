package Homework.No_7;

import java.util.Scanner;

class Account {
    private String name;
    private int balance;

    protected Account() {
        name = "홍길동"; balance = 10000;
        System.out.println(name + "님의 새로운 계좌가 만들어졌습니다. 잔고: " + balance);
    }
    protected Account(String name, int balance) {
        this.name = name; this.balance = balance;
        System.out.println(name + "님의 새로운 계좌가 만들어졌습니다. 잔고: " + this.balance);
    }

    protected void deposit(int amount) {
        balance += amount;
        System.out.println(name + "님의 저축 금액: " + amount + " 잔고: " + balance);
    }
    protected void withdraw(int amount) {
        balance -= amount;
        System.out.println(name + "님의 인출 금액: " + amount + " 잔고: " + balance);
    }
    protected void printBalance() {
        System.out.println(name + "님의 계좌 잔고: " + balance);
    }
    protected void transfer(int amount, Account account) {
        balance -= amount; account.balance += amount;
        System.out.println(amount + " 송금되었습니다. " + name + "님의 계좌 잔고: " + balance);
        System.out.println(account.name + "님의 계좌 잔고: " + account.balance);
    }

    protected String getName() { return name; }
    protected int getBalance() { return balance; }
    protected void setName(String name) { this.name = name; }
    protected void setBalance(int balance) { this.balance = balance; }
}

public class AccountTest {
    public static void main(String[] args) {
        Account[] accounts = new Account[2];
        Scanner scanner = new Scanner(System.in);
        for (int i = 0; i < accounts.length; i++) {
            System.out.print("계좌명과 개설금액 입력>>");
            accounts[i] = new Account(scanner.next(), scanner.nextInt());
        }
        while (true) {
            System.out.print("*1. 입금 2. 인출 3. 잔고확인 4. 송금 5. 종료 ** : ");
            int input = scanner.nextInt();
            if (input == 1) {
                System.out.print("계좌명>> ");
                String depositName = scanner.next();
                int indexA = -1;
                for (int i = 0; i < accounts.length; i++) {
                    if (depositName.equals(accounts[i].getName())) {
                        indexA = i;
                        break;
                    }
                }
                if (indexA != -1) {
                    System.out.print("입금할 금액>> ");
                    accounts[indexA].deposit(scanner.nextInt());
                } else {
                    System.out.println("계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                }
            } else if (input == 2) {
                System.out.print("계좌명>> ");
                String withdrawName = scanner.next();
                int indexB = -1;
                for (int i = 0; i < accounts.length; i++) {
                    if (withdrawName.equals(accounts[i].getName())) {
                        indexB = i;
                        break;
                    }
                }
                if (indexB != -1) {
                    System.out.print("인출할 금액>> ");
                    accounts[indexB].withdraw(scanner.nextInt());
                } else {
                    System.out.println("계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                }
            } else if (input == 3) {
                System.out.print("계좌명>> ");
                String printBalanceName = scanner.next();
                int indexC = -1;
                for (int i = 0; i < accounts.length; i++) {
                    if (printBalanceName.equals(accounts[i].getName())) {
                        indexC = i;
                        break;
                    }
                }
                if (indexC != -1) {
                    accounts[indexC].printBalance();
                } else {
                    System.out.println("계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                }
            } else if (input == 4) {
                System.out.print("계좌명>> ");
                String transferToName = scanner.next();
                int indexD = -1;
                for (int i = 0; i < accounts.length; i++) {
                    if (transferToName.equals(accounts[i].getName())) {
                        indexD = i;
                        break;
                    }
                }
                if (indexD != -1) {
                    System.out.print("송금 계좌명(송금취소 exit입력)>> ");
                    String transferFromName = scanner.next();
                    if (transferFromName.equals("exit")) {
                        System.out.println("송금 취소!!");
                        continue;
                    }
                    int indexE = -1;
                    for (int i = 0; i < accounts.length; i++) {
                        if (transferFromName.equals(accounts[i].getName())) {
                            indexE = i;
                            break;
                        }
                    }
                    if (indexE != -1) {
                        System.out.print("송금할 금액>> ");
                        accounts[indexD].transfer(scanner.nextInt(), accounts[indexE]);
                    } else {
                        System.out.println("송금 계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                    }
                } else {
                    System.out.println("계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                }
            } else if (input == 5) {
                System.out.println("프로그램을 종료합니다. ");
                break;
            } else {
                System.out.println("잘못 입력하셨습니다");
            }
        }
    }
}
