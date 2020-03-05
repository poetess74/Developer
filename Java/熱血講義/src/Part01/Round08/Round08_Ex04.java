package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round08_Ex04 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        String[] subjectName = {"국어", "영어", "수학"};
        int[] subjectScore = new int[subjectName.length + 1];
        for (int i = 0; i < subjectScore.length - 1; i++) {
            do {
                System.out.print(subjectName[i] + " = ");
                subjectScore[i] = Integer.parseInt(in.readLine());
            } while (subjectScore[i] < 0 || subjectScore[i] > 100);
            subjectScore[subjectScore.length - 1] += subjectScore[i];
        }
        float avg = subjectScore[subjectScore.length - 1] / (float)(subjectScore.length - 1);
        System.out.println();
        System.out.println("총점 = " + subjectScore[subjectScore.length - 1]);
        System.out.println("평균 = " + avg);
    }
}
