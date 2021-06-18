package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round08_Ex06 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        String[] subjectName = {"국어", "영어", "수학"};
        int[][] subjectPeople = new int[3][subjectName.length + 1];
        float[] avg = new float[3];
        for (int k = 0; k < subjectPeople.length; k++) {
            for (int i = 0; i < subjectPeople[k].length - 1; i++) {
                do {
                    System.out.print(subjectName[i] + " = ");
                    subjectPeople[k][i] = Integer.parseInt(in.readLine());
                } while (subjectPeople[k][i] < 0 || subjectPeople[k][i] > 100);
                subjectPeople[k][subjectPeople[k].length - 1] += subjectPeople[k][i];
            }
            avg[k] = subjectPeople[k][subjectPeople[k].length - 1] / (float)(subjectPeople[k].length - 1);
        }
        for (int k = 0; k < subjectPeople.length; k++) {
            System.out.println();
            System.out.println("총점 = " + subjectPeople[k][subjectPeople[k].length - 1]);
            System.out.println("평균 = " + avg[k]);
        }
    }
}
