#include <stdio.h>

struct contact {
    char name[20];
    char phone[20];
    int ringtone;
};

int main() {
    printf("contact size = %d\n", sizeof(struct contact));
//  printf("contact size = %d\n", sizeof(contact));
    
    return 0;
}

void test() {
    struct contact c1;
}
