package Second_Semester.No_4;

abstract class Food {
	private String foodName;
	public String getFoodName() { return foodName; }
	public void setFoodName(String foodName) { this.foodName = foodName; }
	public Food(String foodName) { this.foodName = foodName; }

	public abstract void cook();
	public abstract void taste();
}

class Noodle extends Food {
	public Noodle(String foodName) { super(foodName); }
	public void cook() { System.out.println("물 넣고 면 넣고 끓이기"); }
	public void taste() { System.out.println("맛있다."); }
}

class FriedRice extends Food {
	public FriedRice(String foodName) { super(foodName); }
	public void cook() { System.out.println("야채와 밥넣고 볶기"); }
	public void taste() { System.out.println("고슬고슬 맛있다."); }
}
public class FoodTest {
	public static void main(String[] args) {
		Food[] array = new Food[2];
		array[0] = new Noodle("라면");
		array[1] = new FriedRice("볶음밥");
		for(var index:array) {
			System.out.println("음식명: " + index.getFoodName());
			System.out.print("요리법: "); index.cook();
			if(index instanceof Noodle) { System.out.println("파 추가"); }
			System.out.print("음식맛: "); index.taste();
			System.out.println("*************************");
		}
	}
}
