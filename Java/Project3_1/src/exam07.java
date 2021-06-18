//Unstable

public class exam07 {
    public static void main(String args[]){
        Car myCar1 = new Car("Red", 0);
        Car myCar2 = new Car("Blue", 0);
        Car myCar3 = new Car("Green", 0);

        myCar1.upSpeed(50);
        System.out.println("자동차 1의 색상은 " + myCar1.getColor() + "이며 속도는 " + myCar1.getSpeed() + "입니다. ");

        myCar2.upSpeed(20);
        System.out.println("자동차 2의 색상은 " + myCar1.getColor() + "이며 속도는 " + myCar1.getSpeed() + "입니다. ");

        myCar3.upSpeed(250);
        System.out.println("자동차 3의 색상은 " + myCar1.getColor() + "이며 속도는 " + myCar1.getSpeed() + "입니다. ");
    }
}
