#include <stdio.h>
#include <string.h>

int main() {
    char buff[BUFSIZ];
    char filename[128] = "";
    FILE *fp = NULL;

    printf("INSERT FILE NAME : ");
    gets(filename);
    fp = fopen(filename, "r");
    if (fp == NULL) {
        printf("ERROR : No such file in %s:%d\n", __FILE__, __LINE__);
        return 1;
    }
    while (fgets(buff, sizeof(buff), fp) != 0) {
        fputs(buff, stdout);
    }
    fclose(fp);

    return 0;
}

