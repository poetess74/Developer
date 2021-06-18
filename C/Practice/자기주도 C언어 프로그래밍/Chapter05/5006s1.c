#include <stdio.h>

int main() {
    int age; char gender;
    scanf("%c %d", &gender, &age);
    if (age >= 18) {
        if (gender == 'M') {
            printf("MAN\n");
        } else if (gender == 'F'){
            printf("WOMEN\n");
        } else {
            printf("INCURRECT");
        }
    } else {
        if (gender == 'M') {
            printf("BOY\n");
        } else if (gender == 'F'){
            printf("GIRL\n");
        } else {
            printf("INCURRECT");
        }
    }
    return 0;
}
