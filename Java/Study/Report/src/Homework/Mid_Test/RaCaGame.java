package Homework.Mid_Test;

public class RaCaGame {
    public static final int RABBIT = 0;
    public static final int CARROT = 1;

    public static final int MAX_X = 20;
    public static final int MAX_Y = 10;
    private char[][] map = new char[MAX_Y][MAX_X];
    private GameObject[] gameObjects = new GameObject[2];
    private int state;

    public void setState(int state) { this.state = state; }
    public int getState() { return state; }

    public RaCaGame() {
        for (int i = 0; i < MAX_Y; i++) {
            for (int j = 0; j < MAX_X; j++) {
                map[i][j] = '-';
            }
        }
        gameObjects[RABBIT] = new Rabbit(0, 0, 1);
        gameObjects[CARROT] = new Carrot(5, 5, 1);
        state = 0;
    }

    public void init() {
        System.out.println("** Rabbit의 Carrot먹기 게임을 시작합니다. **");
    }
    public void update() {
        for (int i = gameObjects.length - 1; i >= 0; i--) {
            map[gameObjects[i].getY()][gameObjects[i].getX()] = gameObjects[i].getShape();
        }
    }
    public void clear() {
        for (int i = 0; i < MAX_Y; i++) {
            for (int j = 0; j < MAX_X; j++) {
                map[i][j] = '-';
            }
        }
    }
    public void draw() {
        System.out.println();
        for (int i = 0; i < MAX_Y; i++) {
            for (int j = 0; j < MAX_X; j++) {
                System.out.print(map[i][j]);
            }
            System.out.println();
        }
    }

    public static void main(String[] args) {
        RaCaGame raCaGame = new RaCaGame();
        raCaGame.init();

        while (raCaGame.getState() == 0) {
            raCaGame.clear();
            raCaGame.update();
            raCaGame.draw();

            raCaGame.gameObjects[RaCaGame.RABBIT].move();
            raCaGame.gameObjects[RaCaGame.CARROT].move();

            if (raCaGame.gameObjects[0].collide(raCaGame.gameObjects[1])) {
                raCaGame.setState(1);
            }
        }
        raCaGame.clear();
        raCaGame.update();
        raCaGame.draw();
        System.out.println(raCaGame.getState() == 1 ? "Rabbit Wins!!" : "Carrot Wins!!");
    }
}
