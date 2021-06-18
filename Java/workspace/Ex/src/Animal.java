
public class Animal {
	private int weight;
	
	public Animal(int weight) {
		this.weight = weight;
	}
	
	public int getWeight() {
		return weight;
	}
	
	public void bark() {
		System.out.println("�� ����ٴϱ�");
	}
}

class Dog extends Animal {
	public Dog() {
		super(50);
	}
	
	public void bark() {
		System.out.println("�۸�");
	}
}

class Cat extends Animal {
	public Cat() {
		super(10);
	}
	
	public void bark() {
		System.out.println("�Ŀ�");
	}
}
