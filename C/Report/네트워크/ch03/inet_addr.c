#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>

int main(int argc, char * argv[]) {
    if (argc != 3) {
        printf("Usage : %s [addr1 (IP)] [addr2 (IP)]\n", argv[0]);
        exit(1);
    }
    char *addr1 = argv[1];
    char *addr2 = argv[2];

    unsigned long conv_addr = inet_addr(addr1);
    if(conv_addr == INADDR_NONE) {
        printf("Error occured!\n");
    } else {
        printf("Network ordered interger addr: %#lx\n", conv_addr);
    }

    conv_addr = inet_addr(addr2);
    if(conv_addr == INADDR_NONE) {
        printf("Error occured!\n");
    } else {
        printf("Network ordered interger addr: %#lx\n", conv_addr);
    }
    return 0;
}
