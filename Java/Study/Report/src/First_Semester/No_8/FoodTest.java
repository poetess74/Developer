package First_Semester.No_8;

abstract class Food {
    private String foodName;

    protected void setFoodName(String foodName) { this.foodName = foodName; }
    protected String getFoodName() { return foodName; }

    protected Food(String foodName) { this.foodName = foodName; }
    protected void print() {
        System.out.println("음식명: " + foodName);
    }
    abstract protected void cook();
    abstract protected void taste();
}
class Noodle extends Food {
    protected Noodle(String foodName) { super(foodName); }

    @Override
    protected void cook() { System.out.println("끓는 물에 라면과 스프를 넣고 2분간 끓인다. "); }
    protected void taste() { System.out.println("개운하고 구수한 맛이 난다"); }
}

class FriedRice extends Food {
    protected FriedRice(String foodName) { super(foodName); }
    @Override
    protected void cook() { System.out.println("밥과 각종 야채를 기름에 볶는다. "); }
    protected void taste() { System.out.println("밥이 고슬고슬하고 잘 볶아진 야채가 잘 어우러진다. "); }
}

public class FoodTest {
    public static void main(String[] args) {
        Food[] foods = new Food[2];
        foods[0] = new Noodle("라면");
        foods[1] = new FriedRice("볶음밥");
        for (Food food : foods) {
            food.print();
            System.out.print("요리법: "); food.cook();
            if (food instanceof Noodle) {
                System.out.println("파를 넣는다");
            }
            System.out.print("음식맛: "); food.taste();
            System.out.println("*****************************************");
        }
    }
}
