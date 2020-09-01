package First_Semester.No_5;

class Phone {
    private String year;
    private int volume;

    protected int getVolume() { return volume; }
    protected void setVolume(int volume) { this.volume = volume; }
    protected String getYear() { return year; }
    protected void setYear(String year) { this.year = year; }

    protected void showMakeDate() { System.out.println("출시 년도: " + year); }
    protected void volumeUp() { this.volume += 10; }
    protected void volumeDown() { this.volume -= 10; }
    protected Phone() {
        volume = 0;
        year = "2020.5.5.";
    }
    protected Phone(String year, int volume) {
        this.year = year;
        this.volume = volume;
    }
}

public class PhoneID {
    public static void main(String[] args) {
        Phone phone = new Phone();
        System.out.println(phone.getVolume());
        phone.setVolume(100);
        System.out.println(phone.getVolume());
    }
}
