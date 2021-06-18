#include <stdio.h>
#include <string.h>
#define STR_SIZE 20

typedef struct contact {
    char name[STR_SIZE];
    char phone[STR_SIZE];
    int ringtone;
} CONTACT;

int main() {
    CONTACT array[] = {
        {"TestUser", "05085928583", 0},
        {"TestUser 1", "88495782548", 7},
        {"TestUser 2", "38257392848", 3},
        {"TestUser 3", "29583829032", 5},
        {"TestUser 4", "48284729381", 1},
    };
    int size = sizeof(array) / sizeof(array[0]);
    char name[STR_SIZE];
    int index;
    CONTACT *recent = NULL;

    while (1) {
        printf("NAME : ");
        scanf("%s", name);
        if (strcmp(name, ".") == 0) {
            break;
        }
        index = -1;
        for (int i = 0; i < size; i++) {
            if (strcmp(array[i].name, name) == 0) {
                index = i;
                break;
            }
        }
        if (index >= 0) {
            printf("Call %s to %s number\n", array[index].name, array[index].phone);
            recent = &array[index];
        } else {
            printf("No such contact\n");
        }
    }
    if (recent) {
        printf("Recent call : %s %s\n", recent -> name, recent -> phone);
    }
    return 0;
}
