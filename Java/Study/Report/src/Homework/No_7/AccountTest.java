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
            if (input == 5) {
                System.out.println("프로그램을 종료합니다. ");
                break;
            }
            String depositName = scanner.next();
            int result = checkAccount(accounts, depositName);
            if (result != -1) {
                if (input == 1) {
                    System.out.print("입금할 금액>> ");
                    accounts[result].deposit(scanner.nextInt());
                } else if (input == 2) {
                    System.out.print("인출할 금액>> ");
                    accounts[result].withdraw(scanner.nextInt());
                } else if (input == 3) {
                    accounts[result].printBalance();
                } else if (input == 4) {
                    System.out.print("송금 계좌명(송금취소 exit입력)>> ");
                    String transferFromName = scanner.next();
                    if (transferFromName.equals("exit")) {
                        System.out.println("송금 취소!!");
                        continue;
                    }
                    int fromIndex = checkAccount(accounts, transferFromName);
                    if (fromIndex != -1) {
                        System.out.print("송금할 금액>> ");
                        accounts[result].transfer(scanner.nextInt(), accounts[fromIndex]);
                    } else {
                        System.out.println("송금 계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                    }
                } else {
                    System.out.println("잘못 입력하셨습니다");
                }
            } else {
                System.out.println("계좌명이 정확하지 않습니다. 다시 시작하세요. ");
                continue;
            }

        }
    }
    protected static int checkAccount(Account[] account, String name) {
        int index = -1;
        for (int i = 0; i < account.length; i++) {
            if (name.equals(account[i].getName())) {
                index = i;
                break;
            }
        }
        return index;
    }
}
