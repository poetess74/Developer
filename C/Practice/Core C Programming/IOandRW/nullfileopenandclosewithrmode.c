#include <stdio.h>

int main() {
    FILE *fp = NULL;

    fp = fopen("data/null.txt", "r");
    if (fp == NULL) {
        printf("No such file or directory. \n");
        return -1;
    }
    printf("Successfully opened file. \n");

    return 0;
}
