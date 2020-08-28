package Homework.No_4;

public class Boiler {
    int temp;
    protected Boiler(int temp) {
        this.temp = temp;
    }
    protected Boiler() {
        temp = 0;
    }
    protected int tempUp() {
        temp++;
        return temp;
    }
    protected int tempDown() {
        temp--;
        return temp;
    }
    protected int tempUpDown(int temp) {
        this.temp += temp;
        return this.temp;
    }
}
