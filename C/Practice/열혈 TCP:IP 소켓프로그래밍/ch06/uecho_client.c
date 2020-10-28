#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/udp_header.h"

int main(int argc, char *argv[]) {
    int sock, str_len, size;
    char message[BUF_SIZE];
    socklen_t addr_size;

    struct sockaddr_in serv_addr, from_addr, get_addr;
    
    size = sizeof(get_addr);
    if(argc != 3) {
        printf("Usage : %s [IP] [port]\n", argv[0]);
        exit(1);
    }

    sock = socket(PF_INET, SOCK_DGRAM, 0);
    if(sock == -1) {
        error_handling("socket() error");
    }

    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = inet_addr(argv[1]);
    serv_addr.sin_port = htons(atoi(argv[2]));

    getsockname(sock, (struct sockaddr *)&get_addr, &size);
    printf("client IP : %s, port : %d\n", inet_ntoa(get_addr.sin_addr), ntohs(get_addr.sin_port));

    while(TRUE) {
        fputs("Insert message (q to exit) : ", stdout);
        fgets(message, sizeof(message), stdin);
        if (!strcmp(message, "q\n") || !strcmp(message, "Q\n")) {
            break;
        }
        sendto(sock, message, strlen(message), 0, (struct sockaddr*)&serv_addr, sizeof(serv_addr));

        getsockname(sock, (struct sockaddr *)&get_addr, &size);
        printf("client IP : %s, port : %d\n", inet_ntoa(get_addr.sin_addr), ntohs(get_addr.sin_port));

        addr_size = sizeof(from_addr);
        str_len = recvfrom(sock, message, BUF_SIZE, 0, (struct sockaddr*)&from_addr, &addr_size);
        message[str_len] = 0;
        printf("Message from server: %s", message);
    }
    close(sock);
    return 0;
}
