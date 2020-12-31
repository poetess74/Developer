#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/udp_header.h"

int main(int argc, char *argv[]) {
    int serv_sock, str_len;
    char message[BUF_SIZE];
    socklen_t clnt_addr_size;

    struct sockaddr_in serv_addr, clnt_addr;
    if (argc != 2) {
        printf("Usage : %s [port]\n", argv[0]);
        exit(1);
    }

    serv_sock = socket(PF_INET, SOCK_DGRAM, 0);
    if (serv_sock == -1) {
        error_handling("UDP socket creation error");
    }
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    if (bind(serv_sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("bind() error");
    }

    while(TRUE) {
        clnt_addr_size = sizeof(clnt_addr);
        str_len = recvfrom(serv_sock, message, BUF_SIZE, 0, (struct sockaddr*)&clnt_addr, &clnt_addr_size);
        message[str_len] = 0;
        printf("client message : %s\n", message);
        printf("Client IP : %s, Port : %d\n", inet_ntoa(clnt_addr.sin_addr), ntohs(clnt_addr.sin_port));
        sendto(serv_sock, message, str_len, 0, (struct sockaddr*)&clnt_addr, clnt_addr_size);
    }
    close(serv_sock);
    return 0;
}
