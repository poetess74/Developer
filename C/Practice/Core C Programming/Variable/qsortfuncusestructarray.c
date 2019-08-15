#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define STR_SIZE 20

typedef struct contact {
    char name[STR_SIZE];
    char phone[STR_SIZE];
    int ringtone;
} CONTACT;

int compare_by_name(const void *e1, const void *e2);
void print_contacts(const CONTACT *array, int size);

int main() {
    CONTACT array[] = {
        {"TestUser 4", "05383928572", 0},
        {"TestUser 3", "02386923571", 1},
        {"TestUser 2", "01353978275", 4},
        {"TestUser 1", "02383521274", 7},
        {"TestUser", "02384928570", 3},
    };
    int size = sizeof(array) / sizeof(array[0]);

    puts("--- INPUT ---");
    print_contacts(array, size);
    puts("--- RESULT ---");
    qsort(array, size, sizeof(CONTACT), compare_by_name);
    print_contacts(array, size);

    return 0;
}

int compare_by_name(const void *e1, const void *e2) {
    const CONTACT *p1 = (const CONTACT*) e1;
    const CONTACT *p2 = (const CONTACT*) e2;

    return strcmp(p1 -> name, p2 -> name);
}

void print_contacts(const CONTACT *array, int size) {
    printf(" NAME   PHONE   SOUND\n");
    for (int i = 0; i < size; i++) {
        printf("%6s %11s %d\n", array[i].name, array[i].phone, array[i].ringtone);
    }
}
