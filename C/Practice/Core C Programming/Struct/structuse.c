#include <stdio.h>
#include <string.h>

struct contact {
    char name[20];
    char phone[20];
    int ringtone;
};

int main() {
    struct contact ct = {"TestUser", "86223448523", 0};
    struct contact ct1 = {0}, ct2 = {0};

    ct.ringtone = 5;
    strcpy(ct.phone, "86523448523");
    printf("NAME: %s\n", ct.name);
    printf("PHONE: %s\n", ct.phone);
    printf("SOUND: %d\n", ct.ringtone);

    strcpy(ct1.name, "TestUser 1");
    strcpy(ct1.phone, "25365273381");
    ct1.ringtone = 1;
    printf("NAME: %s\n", ct1.name);
    printf("PHONE: %s\n", ct1.phone);
    printf("SOUND: %d\n", ct1.ringtone);

    printf("NAME : ");
    scanf("%s", ct2.name);
    printf("PHONE : ");
    scanf("%s", ct2.phone);
    printf("SOUND : ");
    scanf("%d", &ct2.ringtone);
    printf("NAME: %s\n", ct2.name);
    printf("PHONE: %s\n", ct2.phone);
    printf("SOUND: %d\n", ct2.ringtone);
}
