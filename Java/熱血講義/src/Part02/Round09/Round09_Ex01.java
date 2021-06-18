package Part02.Round09;

class Round09_Ex01 {
    private int[] sub;
    private float avg;
    private Round09_Ex01() {
        sub = new int[4];
        avg = 0.0f;
    }
    private void calc() {
        int total = 0;
        for (int i = 0; i < sub.length; i++) {
            total += sub[i];
        }
        avg = total / sub.length;
    }
    private class Round09_01_Inner {
        private String[] subjectName = {"국어", "영어", "수학"};
        public String getSubjectName(int x) {
            return subjectName[x];
        }
    }
}
