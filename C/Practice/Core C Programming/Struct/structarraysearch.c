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
        {"TestUser", "85592928476", 0}, 
        {"TestUser 1", "29489482024", 3},
        {"TestUser 2", "58393051058", 1},
        {"TestUser 3", "10482057294", 9},
        {"TestUser 4", "20582938275", 7},
    };
    int size = sizeof(array) / sizeof(array[0]);
    char name[STR_SIZE];
    int index;

    printf("NAME : ");
    scanf("%s", name);
    index = -1;
    for (int i = 0; i < size; i++) {
        if (strcmp(array[i].name, name) == 0) {
            index = i;
            break;
        }
    }
    if (index >= 0) {
        printf("%s Phone : %s\n", array[index].name, array[index].phone);
    } else {
        printf("No such contact\n");
    }

    return 0;
}
