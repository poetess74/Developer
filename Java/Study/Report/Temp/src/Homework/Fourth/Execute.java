package Homework.Fourth;

public class Execute {
    public static void main(String[] args) {
        Boiler boiler = new Boiler();
        Boiler boiler1 = new Boiler(25);
        Movie movie = new Movie();
        Movie movie1 = new Movie("로건", 4.1f, 2017);
        movie.print();
        movie1.print();
        System.out.println(boiler.tempUpDown(22));
        System.out.println(boiler1.tempUp());
        System.out.println(boiler.tempDown());
    }
}
