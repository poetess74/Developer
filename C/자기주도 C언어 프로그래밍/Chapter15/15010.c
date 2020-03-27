#include <stdio.h>
#include <stdlib.h>

int main() {
    int dnum1, dnum2, dsum;
    float fnum1, fnum2, fsum;
    char cnum1[11], cnum2[11];
    scanf("%s %s", cnum1, cnum2);
    dnum1 = atoi(cnum1);
    dnum2 = atoi(cnum2);
    dsum = dnum1 + dnum2;
    printf("%d + %d = %d\n", dnum1, dnum2, dsum);
    scanf("%s %s", cnum1, cnum2);
    fnum1 = atof(cnum1);
    fnum2 = atof(cnum2);
    printf("%.2f + %.2f = %.2f\n", fnum1, fnum2, fnum1 + fnum2);
    return 0;
}
