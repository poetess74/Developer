package First_Semester.No_8;

class Animal {
    private String name;
    protected Animal(String name) { this.name = name; }
    void eat() { System.out.println("식사를 해요.");}
    protected String getName() { return name; }
}

class Bird extends Animal {
    protected Bird(String name) { super(name); }
    void fly() {
        System.out.println(getName() + ": 날 수 있어요. ");
    }
    @Override
    void eat() {
        super.eat();
        System.out.println("곤충을 먹어요");
    }
}
public class BirdTest {
    public static void main(String[] args) {
        Bird bird = new Bird("짹짹이");
        bird.eat();
        bird.fly();
    }
}
