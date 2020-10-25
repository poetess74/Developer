#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>

long digitToHex(char *convertDigit);

int main(int argc, char *argv[]) {
    if (argc != 3) {
        printf("Usage : %s [host_port (INT)] [host_addr (INT)]\n", argv[0]);
        exit(1);
    }
    unsigned short host_port = (unsigned short)atol(argv[1]);
    unsigned short net_port;
    unsigned long host_addr = (unsigned int)atol(argv[2]);
    unsigned long net_addr;

    net_port = htons(host_port);

    net_addr = htonl(host_addr);

    printf("Host ordered port: %#x\n", host_port);
    printf("Network ordered port: %#x\n", net_port);
    printf("Host ordered address: %#lx\n", host_addr);
    printf("Network ordered address: %#lx\n", net_addr);
}
