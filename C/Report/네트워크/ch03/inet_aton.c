#include <stdio.h>
#include <stdlib.h>
#include <arpa/inet.h>

void error_handling(char *message);

int main(int argc, char *argv[]) {
    if (argc != 2) {
        printf("Usage : %s [addr (IP)]\n", argv[0]);
        exit(1);
    }
    char *addr = argv[1];
    struct in_addr addr_inet;

    if(!inet_aton(addr, &addr_inet)) {
        error_handling("Conversion error");
    } else {
        printf("Network ordered integer addr: %#x\n", addr_inet.s_addr);
    }
    return 0;
}

void error_handling(char *message) {
    fputs(message, stderr);
    fputc('\n', stderr);
    exit(1);
}
