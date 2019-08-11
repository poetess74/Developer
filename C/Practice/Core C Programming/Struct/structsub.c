#include <stdio.h>
#include <string.h>

struct contact {
    char name[20];
    char phone[20];
    int ringtone;
};

int main() {
    struct contact ct = {"TestUser", "84235719941", 0};
    struct contact ct1 = {"TestUser 1", "25733754441", 1};
    struct contact ct2 = ct1;

    printf("to ct1 init ct2 : %s, %s, %d\n", ct2.name, ct2.phone, ct2.ringtone);

    ct2 = ct;

    printf("to ct init ct2 : %s, %s, %d\n", ct2.name, ct2.phone, ct2.ringtone);

    return 0;
}
