#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "../header/tcp_header.h"

int main(int argc, char *argv[]) {
    int serv_sock, clnt_sock, option, str_len;
    char message[30];
    socklen_t optlen, clnt_addr_size;
    struct sockaddr_in serv_addr, clnt_addr;

    if (argc != 2) {
        printf("Usage : %s [port]\n", argv[0]);
        exit(1);
    }

    serv_sock = socket(PF_INET, SOCK_STREAM, 0);
    if (serv_sock == -1) {
        error_handling("socket() error");
    }

    /*
        optlen = sizeof(option);
        option = TRUE;
        setsockopt(serv_sock, SOL_SOCKET, SO_REUSEADDR, (void*)&option, optlen);
    */

    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
    serv_addr.sin_port = htons(atoi(argv[1]));

    if(bind(serv_sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr))) {
        error_handling("bind() error");
    }
    if (listen(serv_sock, 5) == -1) {
        error_handling("listen() error");
    }
    clnt_addr_size = sizeof(clnt_addr);
    clnt_sock = accept(serv_sock, (struct sockaddr*)&clnt_addr, &clnt_addr_size);
    while((str_len = read(clnt_sock, message, sizeof(message))) != 0) {
        write(clnt_sock, message, str_len);
        write(1, message, str_len);
    }
    close(clnt_sock);
    close(serv_sock);
    return 0;
}
