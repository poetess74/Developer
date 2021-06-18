#include <stdio.h>
#include <string.h>

struct score {
    char name[12];
    int kor, eng;
};

int main() {
    struct score a, b, sum;
    scanf("%s %d %d", a.name, &a.kor, &a.eng);
    scanf("%s %d %d", b.name, &b.kor, &b.eng);

    strcpy(sum.name, "합계");
    sum.kor = a.kor + b.kor;
    sum.eng = a.eng + b.eng;

    printf("%s %d %d\n", a.name, a.kor, a.eng);
    printf("%s %d %d\n", b.name, b.kor, b.eng);
    printf("%s %d %d\n", sum.name, sum.kor, sum.eng);
    return 0;
}
