//Unstable
#include <stdio.h>
#include <stdlib.h>

int main() {
    int result; char input;
    scanf("%s", &input);
    result = (int)input;
    printf("%.2f\n", (float)result * 2);
    return 0;
}
