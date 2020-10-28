#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/tcp_header.h"

int main(int argc, char *argv[]) {
    int serv_sock, clnt_sock, str_len;
    char message[BUF_SIZE];

    struct sockaddr_in serv_addr, clnt_addr;
    socklen_t clnt_addr_size;

    if (argc != 2) {
        printf("Usage : %s [port]\n", argv[0]);
        exit(1);
    }
    serv_sock = socket(PF_INET, SOCK_STREAM, 0);
    if (serv_sock == -1) {
        error_handling("socket() error");
    }
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    if(bind(serv_sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) == -1) {
        error_handling("bind() error");
    }

    if (listen(serv_sock, 5) == -1) {
        error_handling("listen() error");
    }
    
    clnt_addr_size = sizeof(clnt_addr);
    for(int i = 0; i < 5; i++) {
        clnt_sock = accept(serv_sock, (struct sockaddr*)&clnt_addr, &clnt_addr_size);
        if (clnt_sock == -1) {
            error_handling("accept() error");
        } else {
            printf("Connected client %d\n", i + 1);
        }
        printf("client IP: %s, Port: %X, %X\n", inet_ntoa(clnt_addr.sin_addr), clnt_addr.sin_port, ntohs(clnt_addr.sin_port));

        while((str_len = read(clnt_sock, message, BUF_SIZE)) != 0) {
            printf("client message: %s\n", message);
            write(clnt_sock, message, str_len);
        }
        close(clnt_sock);
    }
    close(serv_sock);
    return 0;
}
