#include <stdio.h>
#include <string.h>

struct contact {
    char name[20];
    char phone[20];
    int ringtone;
};

int main() {
    struct contact ct1 = {"TestUser", "40833960028", 1};
    struct contact ct2 = ct1;

    if(strcmp(ct1.name, ct2.name) == 0 && strcmp(ct1.phone, ct2.phone) == 0 && ct1.ringtone == ct2.ringtone) {
        printf("overlaped contacts\n");
    }
    return 0;
}
