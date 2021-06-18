#include <stdio.h>
#include <string.h>
#define STR_SIZE 20

typedef struct contact {
    char name[STR_SIZE];
    char phone[STR_SIZE];
    int ringtone;
} CONTACT;

int main() {
    CONTACT ct = {"TestUser", "58948556683", 0};
    CONTACT *p = &ct;
    p -> ringtone = 5;
    strcpy (p -> phone, "33158390153");
    printf("NAME : %s\n", p -> name);
    printf("PHONE: %s\n", p -> phone);
    printf("SOUND: %d\n", p -> ringtone);

    return 0;
}
