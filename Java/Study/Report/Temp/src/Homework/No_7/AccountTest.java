package Homework.No_7;

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
        Account account = new Account("김영희", 10000);
        Account account1 = new Account("최철수", 50000);
        account.deposit(10000);
        account.withdraw(5000);
        account1.deposit(100000);
        account1.withdraw(30000);
        account.printBalance();
        account1.printBalance();
        account1.transfer(5000, account);
    }
}
