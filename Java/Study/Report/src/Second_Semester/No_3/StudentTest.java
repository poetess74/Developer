package Second_Semester.No_3;

class Student {
	public String name;
	private int grade;
	public int studentClass;

	public void setGrade(int year) { grade = year; }
	public int getGrade() { return grade; }
	public void show() {
		System.out.println("이름: " + name + ", 학년: " + grade + ", 반: " + studentClass);
	}

	public Student() {
		name = "홍길동";
		grade = 2;
		studentClass = 2;
	}

	public Student(String name, int grade, int studentClass) {
		this.name = name;
		this.grade = grade;
		this.studentClass = studentClass;
	}
}

public class StudentTest {
	public static void main(String[] args) {
		Student student1 = new Student();
		Student student2 = new Student("김형민", 2, 1);
		student2.setGrade(3);
		System.out.println("수정된 학년: " + student2.getGrade());
		student1.show();
		student2.show();
	}
}