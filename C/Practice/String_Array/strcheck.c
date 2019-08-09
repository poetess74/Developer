#include <stdio.h>
#include <string.h>
#define SIZE 10

int main() {
    char s1[SIZE] = "apple";
    char s2[SIZE] = "apple";
    char password[SIZE];

    if (s1 == s2) {
        printf("same address\n");
    }

    if (strcmp(s1, s2) == 0) {
        printf("same string\n");
    }

    printf("PW : ");
    scanf("%s", password);
    if(strcmp(password, "abcd1234") == 0) {
        printf("login succeeded\n");
    } else {
        printf("login failed\n");
    }

    return 0;
}
