#include <stdio.h>
#include <string.h>

typedef struct contact {
    char name[20];
    char phone[20];
    int ringtone;
} CONTACT;

int main() {
    CONTACT array[] = {
        {"TestUser", "03288425582", 0}, 
        {"TestUser 1", "06822945823", 1}, 
        {"TestUser 2", "00288472847", 2},
    };
    int size = sizeof(array) / sizeof(array[0]);
    printf(" NAME  PHONE  SOUND\n");
    for (int i = 0; i < size; i++) {
        printf("%6s %11s %d\n", array[i].name, array[i].phone, array[i].ringtone);
    }
    return 0;
}
