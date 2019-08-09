#include <stdio.h>
#include <string.h>

struct score {
    char name[12];
    int kor, eng;
};

int main() {
    struct score a, b, avg;
    scanf("%s %d %d", a.name, &a.kor, &a.eng);
    scanf("%s %d %d", b.name, &b.kor, &b.eng);

    strcpy(avg.name, "평균");
    avg.kor = (a.kor + b.kor) / 2;
    avg.eng = (a.eng + b.eng) / 2;

    printf("%s %d %d\n", a.name, a.kor, a.eng);
    printf("%s %d %d\n", b.name, b.kor, b.eng);
    printf("%s %d %d\n", avg.name, avg.kor, avg.eng);
    return 0;
}
