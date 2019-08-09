#include <stdio.h>
#include <limits.h>

float avg(int a, int b, int c) {
    int sum = a + b + c;
    return (float) sum / 3;
}

int main() {
    int kor = INT_MIN, eng = INT_MIN, mat = INT_MIN;
    float _avg;
    printf("세 과목의 점수를 입력하세요. ");
    scanf("%d %d %d", &kor, &eng, &mat);
    _avg = avg(kor, eng, mat);
    printf("평균 : %.2f\n", _avg);
    return 0;
}
