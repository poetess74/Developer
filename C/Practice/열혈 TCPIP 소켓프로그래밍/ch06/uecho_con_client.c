#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/udp_header.h"

int main(int argc, char* argv[]) {
    int sock, str_len;
    char message[BUF_SIZE];
    struct sockaddr_in serv_addr;
    
    if(argc != 3) {
        printf("Usage : %s [ip] [port]\n", argv[0]);
        exit(1);
    }
    sock = socket(PF_INET, SOCK_DGRAM, 0);
    if (sock == -1) {
        error_handling("socket() error");
    }
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = inet_addr(argv[1]);
    serv_addr.sin_port = htons(atoi(argv[2]));

    connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr));
    while(TRUE) {
        fputs("Insert message (q to exit) : ", stdout);
        fgets(message, sizeof(message), stdin);
        if (!strcmp(message, "q\n") || !strcmp(message, "Q\n")) {
            break;
        }
        write(sock, message, strlen(message));
        str_len = read(sock, message, sizeof(message) - 1);
        message[str_len] = 0;
        printf("Message from server: %s", message);
    }
    close(sock);
    return 0;
}
