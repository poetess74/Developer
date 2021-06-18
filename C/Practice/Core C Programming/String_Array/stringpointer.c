#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main() {
    char str[64] = "";
    char *p = str;

    strcpy(p, "test string");
    
    if (islower(p[0])) {
        p[0] = toupper(p[0]);
    }
    p = strchr(p, ' ');

    if (islower(p[1])) {
        p[1] = toupper(p[1]);
    }
    puts(str);
    return 0;
}
