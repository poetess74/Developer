#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main() {
    char books[5][30] = {
        "wonder",
        "me before you",
        "the hunger games",
        "twilight", 
        "harry potter",
    };
    
    for (int i = 0; i < 5; i++) {
        printf("title : %s\n", books[i]);
    }

    for (int i = 0; i < 5; i++) {
        if (islower(books[i][0])) {
            books[i][0] = toupper(books[i][0]);
        }
    }

    puts("--- RESULT ---");
    for (int i = 0; i < 5; i++) {
        printf("title : %s\n", books[i]);
    }
    return 0;
}
