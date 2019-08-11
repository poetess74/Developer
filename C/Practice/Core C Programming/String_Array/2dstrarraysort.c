#include <stdio.h>
#include <string.h>
#define MAX 5
#define BUF_SZ 30

int swap_string(char * lhs, char * rhs, int size);

int main() {
    char books[MAX][BUF_SZ] = {
        "Wonder",
        "Me before you", 
        "The hunger games", 
        "Twilight", 
        "Harry potter", 
    };
    int index;

    puts("--- BEFORE ---");
    for (int i = 0; i < MAX; i++) {
        puts(books[i]);
    }
    for (int i = 0; i < MAX - 1; i++) {
        index = i;
        for (int j = i + 1; j < MAX; j++) {
            if (strcmp(books[index], books[j]) > 0) {
                index = j;
            }
        }
        if (i != index) {
            swap_string(books[index], books[i], BUF_SZ);
        }
    }

    puts("--- RESULT ---");
    for (int i = 0; i < MAX; i++) {
        puts(books[i]);
    }

    return 0;
}

int swap_string(char * lhs, char * rhs, int size) {
    int lhs_len = strlen(lhs);
    int rhs_len = strlen(rhs);
    char temp[BUF_SZ] = "";

    if (lhs_len + 1 > size || rhs_len + 1 > size) {
        return 0;
    }

    strcpy(temp, lhs);
    strcpy(lhs, rhs);
    strcpy(rhs, temp);

    return 1;
}
