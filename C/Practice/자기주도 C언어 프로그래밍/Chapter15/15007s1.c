//Unstable
#include <stdio.h>
#include <string.h>

int main() {
    int count, flag = 0; char string[100];
    scanf("%s", string);
    count = strlen(string);
    for (int i = 0; i < count; i++) {
/*        if (strchr(string[i], 'c')) {
            flag = 1;
        }*/
    }
    if (flag == 1) {
        printf("Yes ");
        flag = 0;
    } else {
        printf("No ");
    }
    for (int i = 0; i < count; i++) {
/*        if (strstr(string[i], "ab")) {
            flag = 1;
        }*/
    }
    if (flag == 1) {
        printf("Yes \n");
        flag = 0;
    } else {
        printf("No \n");
    }
    return 0;
}
