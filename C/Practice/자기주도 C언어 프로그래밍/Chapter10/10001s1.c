//Unstable
#include <stdio.h>

int main() {
    char CAPS;
    int CHAR[25]={0}, count = 0;

    while (1) {
        scanf(" %c", &CAPS);
        if (CAPS < 'A' || 'Z' < CAPS) {
            break;
        }
        CHAR[CAPS]++;
        count++;
    }
    for (int i = 1; i <= count; i++) {
        printf("%c : %d개\n", CHAR[CAPS], CHAR[i]);
    }
    return 0;
}
