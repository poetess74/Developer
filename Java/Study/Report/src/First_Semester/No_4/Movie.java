package First_Semester.No_4;

public class Movie {
    String title;
    float rating; int release;
    protected Movie() {
        title = "알라딘";
        this.rating = 4.5f;
        release = 2019;
    }
    protected Movie(String title, float rating, int release) {
        this.title = title;
        this.rating = rating;
        this.release = release;
    }
    protected void print() {
        System.out.printf("영화 제목: %s\n영화 평점: %f\n발표 연도: %d\n", title, rating, release);
    }
}
