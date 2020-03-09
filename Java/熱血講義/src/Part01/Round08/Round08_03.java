package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round08_03 {
    private static void sort(int[][] array, int startIndex, int endIndex, int compareColumn, boolean isAscending) {
        for (int i = startIndex; i < endIndex - 1; i++) {
            for (int j = i + 1; j < endIndex; j++) {
                if ((isAscending) ? array[i][compareColumn] > array[j][compareColumn] : array[i][compareColumn] < array[j][compareColumn]) {
                    int[] t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }
            }
        }
    }

    private static void rank(int[][] array, int startIndex, int endIndex, int scoreColumn, int rankColumn) {
        int rank = 0;
        int count = 0;
        int lastScore = -1;

        for (int i = startIndex; i < endIndex; i++) {
            if (array[i][scoreColumn] != lastScore) {
                count++;
                rank = count;
            } else {
                count++;
            }

            lastScore = array[i][scoreColumn];
            array[i][rankColumn] = rank;
        }
    }

    public static void main(String[] args) throws IOException {
        if (args.length != 1) {
            System.out.printf("usage: java Test {num_of_classes}\n");
            System.exit(-1);
        }

        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        int numOfClasses = Integer.parseInt(args[0]);
        int totalStudents = 0;

        int[] numOfStudents = new int[numOfClasses];
        for (int c = 0; c < numOfClasses; c++) {
            System.out.printf("%d반의 인원수 =  ", c + 1);
            numOfStudents[c] = Integer.parseInt(br.readLine());
            totalStudents += numOfStudents[c];
        }

        String[] names = new String[totalStudents];
        int[][] scoreRecords = new int[totalStudents][9]; // 반, 번호, 국, 영, 수, 총점, 반석차, 전교석차

        int index = 0;

        for (int c = 0; c < numOfClasses; c++) {
            System.out.printf("=== %d반 성적처리 ===\n", c + 1);
            for (int s = 0; s < numOfStudents[c]; s++) {
                System.out.printf("%d번 사람 이름 = ", s + 1);
                names[index] = br.readLine();

                scoreRecords[index][0] = c + 1; // 반
                scoreRecords[index][1] = s + 1; // 번호

                System.out.printf("국어= "); scoreRecords[index][2] = Integer.parseInt(br.readLine());
                System.out.printf("영어= "); scoreRecords[index][3] = Integer.parseInt(br.readLine());
                System.out.printf("수학= "); scoreRecords[index][4] = Integer.parseInt(br.readLine());

                scoreRecords[index][5] = scoreRecords[index][2] + scoreRecords[index][3] + scoreRecords[index][4]; // 총점
                scoreRecords[index][8] = index++; // 반, 번호 순 정렬을 위해 index 저장

                System.out.printf("\n");
            }

            System.out.printf("=== %d반 성적처리 끝 ===\n\n", c + 1);
        }

        // 반석차
        int sindex = 0; // N반의 첫번째 학생 index
        int eindex = 0; // N반의 마지막 학생 index

        for (int c = 0; c < numOfClasses; c++) {
            sindex = eindex;
            eindex = sindex + numOfStudents[c];

            sort(scoreRecords, sindex, eindex, 5, false);
            rank(scoreRecords, sindex, eindex, 5, 6);
        }

        // 전교석차
        sort(scoreRecords, 0, totalStudents, 5, false);
        rank(scoreRecords, 0, totalStudents, 5, 7);

        // 반, 번호순 정렬
        sort(scoreRecords, 0, totalStudents, 8, true);

        System.out.printf("============================================================================\n");
        System.out.printf("반  번호    이름    국어  영어  수학    총점   평균   학점  반석차  전교석차\n");
        System.out.printf("============================================================================\n");

        for (int i = 0; i < totalStudents; i++) {
            float avg = scoreRecords[i][5] / 3.0f;
            System.out.printf(
                    "%2d   %2d    %3s    %3d   %3d   %3d     %3d %6.1f     %s     %2d       %3d\n",
                    scoreRecords[i][0],
                    scoreRecords[i][1],
                    names[i],
                    scoreRecords[i][2],
                    scoreRecords[i][3],
                    scoreRecords[i][4],
                    scoreRecords[i][5],
                    avg,
                    (avg >= 90) ? "A" : (avg >= 80) ? "B" : (avg >= 70) ? "C" : (avg >= 60) ? "D" : "F",
                    scoreRecords[i][6],
                    scoreRecords[i][7]);
        }
        System.out.printf("============================================================================\n");
    }
}
