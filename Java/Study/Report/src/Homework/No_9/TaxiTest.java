package Homework.No_9;

interface Meter {
    void start();
    int stop();
}

class Taxi implements Meter {
    private int distance, fee;
    protected void setDistance(int distance) { this.distance = distance; }
    protected int getDistance() { return distance; }
    protected void setFee(int fee) { this.fee = fee; }
    protected int getFee() { return fee; }

    protected Taxi(int setFee) { fee = setFee; distance = 0; }

    public void start() { System.out.println("운행을 시작합니다. "); }
    public int stop() { return distance * fee; }
}

public class TaxiTest {
    public static void main(String[] args) {
        Taxi taxi = new Taxi(1800);
        taxi.start();
        taxi.setDistance(15);
        System.out.printf("운행거리: %dkm\n", taxi.getDistance());
        System.out.printf("요금: ₩%d\n", taxi.stop());
    }
}
