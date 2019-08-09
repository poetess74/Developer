#include <stdio.h>
#include <string.h>

int main() {
    char filename[] = "readme.txt";
    char *p = NULL;

    p = strchr(filename, '.');
    if (p != NULL) {
        printf("File extension: %s\n", p + 1);
    }

    p = strstr(filename, ".txt");

    if (p != NULL) {
        printf("File type : TEXT file\n");
    }

    return 0;
}
