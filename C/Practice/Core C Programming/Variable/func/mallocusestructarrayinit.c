#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <time.h>
#define STR_SIZE 20
#define MAX 100

typedef struct contact {
    char name[STR_SIZE];
    char phone[STR_SIZE];
    int ringtone;
} CONTACT;

int main() {
    CONTACT *array[MAX] = {NULL};
    int count = 0;

    while (count < MAX) {
        char string[STR_SIZE] = "";
        printf("CREATE CONTACT : ");
        scanf("%s", string);
        if (strcmp(string, ".") == 0) {
            break;
        }
        array[count] = (CONTACT*)malloc(sizeof(CONTACT));
        strcpy(array[count] -> name, string);
        printf("INSERT PHONE : ");
        scanf("%s", array[count] -> phone);
        array[count] -> ringtone = 0;
        count++;
    }
    printf(" NAME  PHONE  SOUND\n");
    for (int i = 0; i < count; i++) {
        printf("%6s %11s %d\n", array[i] -> name, array[i] -> phone, array[i] -> ringtone);
    }

    for (int i = 0; i < count; i++) {
        free(array[i]);
        array[i] = NULL;
    }

    return 0;
}
