import java.util.*;

public class Main {
	public static void main(String[] args) {
		ArrayList<Animal> animals = new ArrayList<Animal>();
		
		for (int i = 0 ; i < 100; i++) {
			if ((int)(Math.random() * 2) == 0) {
				animals.add(new Dog());
			} else {
				animals.add(new Cat());
			}
		}
		
		for (Animal animal: animals) {
			animal.bark();
			System.out.println("weight=" + animal.getWeight());
		}
	}
}
