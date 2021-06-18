//exam07 Helper

public class Car {
    String color;
    int speed = 0;
    static int carCount = 0;
    final static int MAXSPEED = 200;
    final static int MINSPEED = 0;

    static int currentCarCount() {
        return carCount;
    }

    Car(String color, int speed) {
        this.color = color;
        this.speed = speed;
        carCount++;
    }

    Car(int speed) {
        this.speed = speed;
    }

    Car() {}

    int getSpeed() {
        return speed;
    }

    void upSpeed(int value) {
        if (speed + value >= 200) {
            speed = 200;
        } else {
            speed = speed + value;
        }
    }

     void downSpeed(int value) {
        if (speed - value <= 0) {
            speed = 0;
        } else {
            speed = speed - value;
        }
    }

    String getColor() {
        return color;
    }
}
