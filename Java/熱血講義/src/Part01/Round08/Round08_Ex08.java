package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round08_Ex08 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        String[] subjectName = {"국어", "영어", "수학"};
        int[][][] subjectPeople = new int[2][3][subjectName.length + 3];
        float[][] avg = new float[2][3];
        for (int h = 0; h < subjectPeople.length; h++) {
            for (int k = 0; k < subjectPeople[h].length; k++) {
                for (int i = 0; i < subjectPeople[h][k].length - 3; i++) {
                    do {
                        System.out.print(subjectName[i] + " = ");
                        subjectPeople[h][k][i] = Integer.parseInt(in.readLine());
                    } while (subjectPeople[h][k][i] < 0 || subjectPeople[h][k][i] > 100);
                    subjectPeople[h][k][subjectPeople[h][k].length - 3] += subjectPeople[h][k][i];
                }
                avg[h][k] = subjectPeople[h][k][subjectPeople[h][k].length - 3] / (float)(subjectPeople[h][k].length - 3);
                subjectPeople[h][k][subjectPeople[h][k].length - 1] = 1;
                subjectPeople[h][k][subjectPeople[h][k].length - 2] = 1;
            }
        }
        for (int h = 0; h < subjectPeople.length; h++) {
            for (int k = 0; k < subjectPeople[h].length; k++) {
                for (int i = 0; i < subjectPeople[h].length; i++) {
                    if(subjectPeople[h][k][subjectPeople[h][k].length - 3] < subjectPeople[h][i][subjectPeople[h][i].length - 3]) {
                        subjectPeople[h][k][subjectPeople[h][k].length - 2]++;
                    }
                }
            }
        }
        for (int h = 0; h < subjectPeople.length; h++) {
            for (int k = 0; k < subjectPeople[h].length; k++) {
                for (int i = 0; i < subjectPeople.length; i++) {
                    for (int j = 0; j < subjectPeople[i].length; j++) {
                        if(subjectPeople[h][k][subjectPeople[h][k].length - 3] < subjectPeople[i][j][subjectPeople[i][j].length - 3]) {
                            subjectPeople[h][k][subjectPeople[h][k].length - 1]++;
                        }
                    }
                }
            }
        }
        for (int h = 0; h < subjectPeople.length; h++) {
            for (int k = 0; k < subjectPeople[h].length; k++) {
                System.out.println();
                System.out.println("총점 = " + subjectPeople[h][k][subjectPeople[h][k].length - 3]);
                System.out.println("평균 = " + avg[h][k]);
                System.out.println("석차 = " + subjectPeople[h][k][subjectPeople[h][k].length - 2] + "등");
                System.out.println("전교석차 = " + subjectPeople[h][k][subjectPeople[h][k].length - 1] + "등");
            }
        }
    }
}
