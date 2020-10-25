#include <stdio.h>
#include <string.h>
#include <arpa/inet.h>

int main(int argc, char *argv[]) {
    struct in_addr addr1, addr2;
    char *str_ptr;
    char str_array[20];

    addr1.s_addr = htonl(0x1020304);
    addr2.s_addr = htonl(0x1010101);

    str_ptr = inet_ntoa(addr1);
    strcpy(str_array, str_ptr);
    printf("Dotted-Decimal notation1: %s\n", str_ptr);

    inet_ntoa(addr2);
    printf("Dotted-Decimal notation2: %s\n", str_ptr);
    printf("Dotted-Decimal notation3: %s\n", str_array);
    return 0;
}
