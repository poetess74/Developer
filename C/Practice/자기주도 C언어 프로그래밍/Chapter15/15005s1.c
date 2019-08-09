#include <stdio.h>
#include <string.h>

int main() {
    char name[20], addedName[10] = {"fighting"};
    scanf("%s", name);
    strcat(name, addedName);
    puts(name);
    return 0;
}
