public class Automobile extends Car {
    int seatNum;

    int getSeatNum() {
        return seatNum;
    }

    void upSpeed(int val) {
        if (speed + val >= 300) {
            speed = 300;
        } else {
            speed = speed + (int)val;
        }
    }
}
