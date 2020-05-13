package Homework.Mid_Test;

public class RaCaGame {
    protected static final int MAX_X = 20;
    protected static final int MAX_Y = 10;
    private char[][] map = new char[MAX_Y][MAX_X];
    private GameObject[] gameObjects = new GameObject[2];
    private int state;

    protected void setState(int state) { this.state = state; }
    protected int getState() { return state; }

    protected RaCaGame() {
        for (int i = 0; i < MAX_Y; i++) {
            for (int j = 0; j < MAX_X; j++) {
                map[i][j] = '-';
            }
        }
        gameObjects[0] = new Rabbit(0, 0, 1);
        gameObjects[1] = new Carrot(5, 5, 2);
        state = 0;
    }

    protected void init() {
        System.out.println("** Rabbit의 Carrot먹기 게임을 시작합니다. **");
    }
    protected void update() {
        for (int i = gameObjects.length - 1; i >= 0; i--) {
            map[gameObjects[i].getY()][gameObjects[i].getX()] = gameObjects[i].getShape();
        }
    }
    protected void clear() {
        for (GameObject gameObject : gameObjects) {
            map[gameObject.getY()][gameObject.getX()] = '-';
        }
    }
    protected void draw() {
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
        for (int i = 0; i < 5; i++) {
            raCaGame.update();
            raCaGame.draw();
            raCaGame.gameObjects[1].move();
            raCaGame.gameObjects[0].move();
            if (raCaGame.gameObjects[0].collide(raCaGame.gameObjects[1])) {
                raCaGame.setState(1);
            }
            raCaGame.clear();
        }
        System.out.println(raCaGame.getState() == 1 ? "Rabbit Wins!!" : "Carrot Wins!!");
    }
}
