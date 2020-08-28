package Homework.No_8;

class Employee {
    private int emNum;
    private String emName;
    private int emSalary;
    private int bonus;

    protected Employee(int emNum, String emName, int emSalary) {
        this.emNum = emNum; this.emName = emName; this.emSalary = emSalary;
        bonus = 0;
    }

    protected int getBonus() { return bonus; }
    protected int getEmNum() { return emNum; }
    protected int getEmSalary() { return emSalary; }
    protected String getEmName() { return emName; }

    protected void setBonus(int bonus) { this.bonus = bonus; }
    protected void setEmName(String emName) { this.emName = emName; }
    protected void setEmNum(int emNum) { this.emNum = emNum; }
    protected void setEmSalary(int emSalary) { this.emSalary = emSalary; }

    protected void print() {
        System.out.println("사번: " + emNum);
        System.out.println("이름: " + emName);
        System.out.println("급여: " + emSalary);
        System.out.println("보너스: " + bonus);
    }
}

class Manager extends Employee {
    private String mission;
    protected Manager(int emNum, String emName, int emSalary, String mission) {
        super(emNum, emName, emSalary);
        this.mission = mission;
    }

    protected void setMission(String mission) { this.mission = mission; }
    protected String getMission() { return mission; }

    @Override
    protected void setBonus(int bonus) { super.setBonus(bonus * 2); }
    protected void print() { super.print(); System.out.println("임무: " + mission); }
}

public class EmployeeTest {
    public static void main(String[] args) {
        Employee[] empArray = new Employee[4];
        Manager manager = new Manager(201805, "김철수", 50, "신입 서류 숙지하기");
        String[] nameArray = {"김영수", "이지영", "박성준", "강수지"};
        int[] salArray = {250, 200, 280, 350};
        int[] bonusArray = {0, 0, 0, 50};

        for(int index = 0; index < empArray.length; index++) {
            empArray[index] = new Employee(201801 + index, nameArray[index], salArray[index]);
            empArray[index].setBonus(bonusArray[index]);
            empArray[index].print();
            System.out.println();
        }
        manager.print();
    }
}
