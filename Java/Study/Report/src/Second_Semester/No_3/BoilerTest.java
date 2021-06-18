package Second_Semester.No_3;

class Boiler {
	private int temp;
	public Boiler(int temp) { this.temp = temp; }
	public Boiler() { temp = 10; }
	public int tempUpDown(int temp) {
		this.temp += temp;
		return this.temp;
	}
	public int getTemp() { return this.temp; }
	public void setTemp(int temp) { this.temp = temp; }
}
public class BoilerTest {
	public static void main(String[] args) {
		Boiler boiler = new Boiler();
		System.out.println(boiler.getTemp());
		boiler.tempUpDown(20);
		System.out.println(boiler.getTemp());
	}
}
