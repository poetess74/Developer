#include <stdio.h>

int main() {
    FILE *fout = NULL;
    FILE *fin = NULL;

    fout = fopen("data/null.txt", "w");
    if (fout == NULL) {
        printf("No such file or directory. \n");
        return -1;
    }
    fclose (fout);
    fin = fopen("data/null.txt", "r");
    if (fin == NULL) {
        printf("No such file or directory. \n");
        return -1;
    }
    printf("Successfuly opened file. \n");
    fclose(fin);

    return 0;
}
